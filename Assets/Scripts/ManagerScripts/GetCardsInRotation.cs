using System.Collections.Generic;
using UnityEngine;

public static class GetCardsInRotation
{
    public static List<MonsterData> GetMonsterInRotation(List<LocationDataTypes.CardLocation> locations)
    {
        List<MonsterData> monsterInRotation = new();
        CardData cardData;
        if (locations.Contains(LocationDataTypes.CardLocation.Hand))
        {
            foreach(Transform cardTransform in GameObject.Find("Hand").transform)
            {
                cardData = cardTransform.GetComponent<InfoRoot>().cardData;
                if (cardData.GetCardInfo().cardType != CardDataTypes.CardType.Monster)
                    continue;
                monsterInRotation.Add((MonsterData)cardData);
            }
        }
        if (locations.Contains(LocationDataTypes.CardLocation.Field))
        {
            foreach(Transform cardTransform in GameObject.Find("SummonedMonsters").transform)
            {
                monsterInRotation.Add((MonsterData)cardTransform.GetComponent<InfoRoot>().cardData);
            }
        }
        if (locations.Contains(LocationDataTypes.CardLocation.Graveyard))
        {
            foreach(LocationDataTypes.CardLocationData cardLocationData in GraveyardManager.instance.GetMonsterInGrave())
            {
                monsterInRotation.Add((MonsterData)cardLocationData.cardData);
            }
        }
        if (locations.Contains(LocationDataTypes.CardLocation.Deck))
        {
            foreach(LocationDataTypes.CardLocationData cardLocationData in DeckManager.instance.GetDeckCardList())
            {
                if(cardLocationData.cardData.GetCardInfo().cardType != CardDataTypes.CardType.Monster)
                    continue;
                monsterInRotation.Add((MonsterData)cardLocationData.cardData);
            }
        }
        //eventually add banishment & extradeck

        return monsterInRotation;
    }
}
