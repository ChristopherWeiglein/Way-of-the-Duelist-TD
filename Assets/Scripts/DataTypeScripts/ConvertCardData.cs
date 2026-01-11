using UnityEngine;

public static class ConvertCardData
{
    public static MonsterData ToMonsterData(CardData cardData) => (MonsterData)cardData;
}
