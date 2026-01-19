using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using MemoryPack;

[MemoryPackable]
[MemoryPackUnion(0,typeof(MonsterData))]
[MemoryPackUnion(1,typeof(SpellData))]
[MemoryPackUnion(2,typeof(BufferSpellData))]
[MemoryPackUnion(3,typeof(ExtraDeckMonsterData))]
[MemoryPackUnion(4,typeof(FusionMonsterData))]
public abstract partial class CardData : ScriptableObject
{
    [SerializeField] private CardDataTypes.CardInfo cardInfo;
    [SerializeField] private bool hasCardSpecificScript;

    public CardDataTypes.CardInfo GetCardInfo() => cardInfo;
    public bool HasCardSpecificScript() => hasCardSpecificScript;
}
