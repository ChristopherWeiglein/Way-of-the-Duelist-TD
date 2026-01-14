using System.Collections.Generic;
using UnityEngine;

public static class CardLocationPairFactory
{
    public static List<LocationDataTypes.CardLocationData> AddLocationsToList(List<CardData> cardList, LocationDataTypes.CardLocation cardLocation)
    {
        List<LocationDataTypes.CardLocationData> list = new(); 
        foreach (CardData card in cardList)
        {
            list.Add(new LocationDataTypes.CardLocationData {correlatingGameObject = null, cardData = card, cardLocation = cardLocation }); 
        }
        return list;
    }

    public static List<LocationDataTypes.CardLocationData> AddLocationsToList(List<LocationDataTypes.CardLocationData> cardList, LocationDataTypes.CardLocation cardLocation)
    {
        List<LocationDataTypes.CardLocationData> list = new();
        foreach (LocationDataTypes.CardLocationData card in cardList)
        {
            list.Add(new LocationDataTypes.CardLocationData {correlatingGameObject = card.correlatingGameObject, cardData = card.cardData, cardLocation = cardLocation });
        }
        return list;
    }

    public static List<CardData> RemoveLocationsFromCardList(List<LocationDataTypes.CardLocationData> cardlist)
    {
        List<CardData> list = new();
        foreach(LocationDataTypes.CardLocationData card in cardlist)
        {
            list.Add(card.cardData);
        }
        return list;
    }

    public static List<MonsterData> RemoveLocationsFromMonsterList(List<LocationDataTypes.CardLocationData> cardlist)
    {
        List<MonsterData> list = new();
        foreach (LocationDataTypes.CardLocationData card in cardlist)
        {
            list.Add(card.cardData as MonsterData);
        }
        return list;
    }
}
