using UnityEngine;

public class EnemyInfo : InfoRoot, IMonsterCard
{
    public CardDataTypes.MonsterInfo MonsterInfo {  get; set; }
}
