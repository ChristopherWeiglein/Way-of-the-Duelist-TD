using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/Monster/FusionMonster")]
public class FusionMonsterData : ExtraDeckMonsterData
{
    [SerializeField] private List<MonsterData> fusionMaterial;

    public List<MonsterData> GetFusionMaterial () => fusionMaterial;
}
