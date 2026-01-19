using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using MemoryPack;

[MemoryPackable]
[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/Monster/FusionMonster")]
public partial class FusionMonsterData : ExtraDeckMonsterData
{
    [SerializeField] private List<MonsterData> fusionMaterial;

    public List<MonsterData> GetFusionMaterial () => fusionMaterial;
}
