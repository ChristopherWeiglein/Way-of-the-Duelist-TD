using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;

    private const int startingHandSize = 5;
    private int cardsDrawnPerTurn = 1;

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

    private void Start()
    {
        DeckManager.instance.DrawCardsFromDeck(startingHandSize);
    }

    private void OnEnable()
    {
        GameManager.OnTurnStart += DrawForTurn;
    }

    private void OnDisable()
    {
        GameManager.OnTurnStart -= DrawForTurn;
    }

    private void DrawForTurn()
    {
        DeckManager.instance.DrawCardsFromDeck(cardsDrawnPerTurn);
    }

    public List<LocationDataTypes.CardLocationData> GetMonstersInHand()
    {
        List<LocationDataTypes.CardLocationData> list = new();

        foreach(Transform child in transform)
        {
            if(child.GetComponent<InfoRoot>().cardData.GetCardInfo().cardType == CardDataTypes.CardType.Monster)
                list.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = child.GetComponent<InfoRoot>().cardData, cardLocation = LocationDataTypes.CardLocation.Hand });
        }

        return list;
    }

    public List<LocationDataTypes.CardLocationData> GetCardsInHand()
    {
        List<LocationDataTypes.CardLocationData> list = new();

        foreach (Transform child in transform)
        {
            list.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = child.GetComponent<InfoRoot>().cardData, cardLocation = LocationDataTypes.CardLocation.Hand });
        }

        return list;
    }
}
