using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/Spells/FieldSpells")]
public class BufferSpellData : SpellData
{
    [SerializeField] private GameObject towerPrefab;

    public GameObject GetTowerPrefab() => towerPrefab;
}
