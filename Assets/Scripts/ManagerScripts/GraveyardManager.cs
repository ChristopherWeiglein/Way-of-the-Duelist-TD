using System.Collections.Generic; 
using TMPro;
using UnityEngine;

public class GraveyardManager : MonoBehaviour
{
    public static GraveyardManager instance;
    [SerializeField] TMP_Text text;

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

    private void OnEnable()
    {
        GameManager.OnCardSentToGrave += ShowGraveyardSize;
    }

    private void OnDisable()
    {
        GameManager.OnCardSentToGrave -= ShowGraveyardSize;
    }

    private void ShowGraveyardSize()
    {
        text.text = transform.childCount.ToString();
    }

    private void OnMouseDown()
    {
        if (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            return;

        List<LocationDataTypes.CardLocationData> graveyardList = GetGraveyardCardList();
        OptionsManager.instance.ShowOptions(graveyardList);
    }

    public List<LocationDataTypes.CardLocationData> GetGraveyardCardList()
    {
        List<LocationDataTypes.CardLocationData> graveyardList = new();
        foreach (Transform child in transform)
        {
            InfoRoot infoRoot = child.GetComponent<IGraveyardCard>() as InfoRoot;
            graveyardList.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = infoRoot.cardData, cardLocation = LocationDataTypes.CardLocation.Graveyard});
        }
        return graveyardList;
    }

    public List<LocationDataTypes.CardLocationData> GetMonsterInGrave()
    {
        List<LocationDataTypes.CardLocationData> graveyardList = new();
        foreach (Transform child in transform)
        {
            InfoRoot infoRoot = child.GetComponent<IGraveyardCard>() as InfoRoot;
            if(infoRoot.cardData.GetCardInfo().cardType == CardDataTypes.CardType.Monster)
                graveyardList.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = infoRoot.cardData, cardLocation = LocationDataTypes.CardLocation.Graveyard });
        }
        return graveyardList;
    }
}
