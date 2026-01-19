using MemoryPack;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/Monster/NormalMonster")]
[MemoryPackable]
public partial class MonsterData : CardData
{
    [SerializeField] private CardDataTypes.MonsterInfo monsterInfo;
    [SerializeField] private GameObject towerPrefab;

    public CardDataTypes.MonsterInfo GetMonsterInfo() => monsterInfo;
    public GameObject GetTowerPrefab() => towerPrefab;
}
