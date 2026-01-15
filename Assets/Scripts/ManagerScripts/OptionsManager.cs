using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager instance;
    public LocationDataTypes.CardLocationData SelectedCard { get; private set; }
    [SerializeField] private GameObject cardSelectionPrefab;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public bool ShowOptions(List<LocationDataTypes.CardLocationData> cardData)
    {
        if (cardData.Count <= 0)
        {
            TextMessageManager.instance.ShowMessageForSeconds("No target available", 3);
            return false;
        }
            

        SelectedCard = new LocationDataTypes.CardLocationData();
        StartCoroutine(SelectionSequence(cardData));
        return true;
    }

    public void SelectCard(LocationDataTypes.CardLocationData cardData)
    {
        SelectedCard = cardData;
    }

    private IEnumerator SelectionSequence(List<LocationDataTypes.CardLocationData> cardData)
    {
        GameManager.EnterSelectionMode();
        foreach (LocationDataTypes.CardLocationData card in cardData)
            CreateCard(card);
        while(SelectedCard.cardData == null)
            yield return null;
        GameManager.LeaveSelectionMode();
    }

    public void CreateCard(LocationDataTypes.CardLocationData cardData)
    {
        GameObject newCard = Instantiate(cardSelectionPrefab, transform.position, transform.rotation, transform);
        newCard.GetComponent<SpriteRenderer>().sprite = cardData.cardData.GetCardInfo().sprite;
        newCard.GetComponent<InfoRoot>().cardData = cardData.cardData;
        newCard.GetComponent<CardLocationUIManager>().cardLocationData = cardData;
    }

}
