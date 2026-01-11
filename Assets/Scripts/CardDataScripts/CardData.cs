using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public abstract class CardData : ScriptableObject
{
    [SerializeField] private CardDataTypes.CardInfo cardInfo;
    [SerializeField] private bool hadCardSpecificScript;

    public CardDataTypes.CardInfo GetCardInfo() => cardInfo;
    public bool HasCardSpecificScript() => hadCardSpecificScript;
}
