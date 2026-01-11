using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class CardData : ScriptableObject
{
    [SerializeField] private CardDataTypes.CardInfo cardInfo;
    [SerializeField] private bool hasCardSpecificScript;

    public CardDataTypes.CardInfo GetCardInfo() => cardInfo;
    public bool HasCardSpecificScript() => hasCardSpecificScript;
}
