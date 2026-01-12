using System;
using UnityEngine;

[Serializable]
public  class DeckEditorDataTypes
{
    public CardData cardData;
    public int amount;

    public DeckEditorDataTypes(CardData cardData, int amount)
    {
        this.cardData = cardData;
        this.amount = amount;
    }
}
