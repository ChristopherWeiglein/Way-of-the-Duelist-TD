using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using MemoryPack;

public abstract partial class CardData : ScriptableObject
{
    [SerializeField] private CardDataTypes.CardInfo cardInfo;
    [SerializeField] private bool hasCardSpecificScript;

    public CardDataTypes.CardInfo GetCardInfo() => cardInfo;
    public bool HasCardSpecificScript() => hasCardSpecificScript;
}
