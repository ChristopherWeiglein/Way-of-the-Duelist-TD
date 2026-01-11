using UnityEngine;
using System.Collections.Generic;

public class MonsterGraveyardCardInfo : InfoRoot, IGraveyardCard, IMonsterCard
{

    public List<CardDataTypes.CardTags> cardTags {  get; set; }
    public CardDataTypes.MonsterInfo MonsterInfo { get; set; }
}
