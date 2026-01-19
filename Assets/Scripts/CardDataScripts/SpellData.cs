using MemoryPack;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/Spells/NormalSpells")]
[MemoryPackable]
public partial class SpellData : CardData
{
    [SerializeField] private CardDataTypes.SpellType spellType;

    public CardDataTypes.SpellType GetSpellType() => spellType;
}
