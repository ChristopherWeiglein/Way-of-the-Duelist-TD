using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager instance;
    public CardData selectedCard { get; private set; }
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

    public void ShowOptions(List<CardData> cardData)
    {
        if (cardData.Count <= 0)
            return;

        selectedCard = null;
        StartCoroutine(SelectionSequence(cardData));
    }

    public void SelectCard(CardData cardData)
    {
        selectedCard = cardData;
    }

    private IEnumerator SelectionSequence(List<CardData> cardData)
    {
        GameManager.EnterSelectionMode();
        foreach (CardData card in cardData)
            CreateCard(card);
        while(selectedCard == null)
            yield return null;
        GameManager.LeaveSelectionMode();
    }

    public void CreateCard(CardData cardData)
    {
        GameObject newCard = Instantiate(cardSelectionPrefab, transform.position, transform.rotation, transform);
        newCard.GetComponent<SpriteRenderer>().sprite = cardData.GetCardInfo().sprite;
        newCard.GetComponent<CardInfoManager>().cardData = cardData;
    }

}
