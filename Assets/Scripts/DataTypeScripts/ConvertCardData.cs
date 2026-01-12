using System.Collections.Generic;
using UnityEngine;

public static class ConvertCardData
{
    public static MonsterData ToMonsterData(CardData cardData) => (MonsterData)cardData;

    public static List<ExtraDeckMonsterData> ToExtraDeckMonsterList(List<CardData> cardlist)
    {
        List<ExtraDeckMonsterData> list = new();
        foreach (CardData cardData in cardlist)
        {
            list.Add((ExtraDeckMonsterData)cardData);
        }
        return list;
    }
}
