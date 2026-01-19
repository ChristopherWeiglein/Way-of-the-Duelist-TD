using System.Collections.Generic;
using UnityEngine;
using MemoryPack;

[MemoryPackable]
[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/Spells/FieldSpells")]
public partial class BufferSpellData : SpellData
{
    [SerializeField] private GameObject towerPrefab;

    public GameObject GetTowerPrefab() => towerPrefab;
}
