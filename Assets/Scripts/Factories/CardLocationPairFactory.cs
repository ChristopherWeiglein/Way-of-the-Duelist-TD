using System.Collections.Generic;
using UnityEngine;

public static class CardLocationPairFactory
{
    public static List<LocationDataTypes.CardLocationData> AddLocationsToList(List<CardData> cardList, LocationDataTypes.CardLocation cardLocation)
    {
        List<LocationDataTypes.CardLocationData> list = new(); 
        foreach (CardData card in cardList)
        {
            list.Add(new LocationDataTypes.CardLocationData {gameObject = null, cardData = card, cardLocation = cardLocation }); 
        }
        return list;
    }

    public static List<LocationDataTypes.CardLocationData> AddLocationsToList(List<LocationDataTypes.CardLocationData> cardList, LocationDataTypes.CardLocation cardLocation)
    {
        List<LocationDataTypes.CardLocationData> list = new();
        foreach (LocationDataTypes.CardLocationData card in cardList)
        {
            list.Add(new LocationDataTypes.CardLocationData {gameObject = card.gameObject, cardData = card.cardData, cardLocation = cardLocation });
        }
        return list;
    }
}
