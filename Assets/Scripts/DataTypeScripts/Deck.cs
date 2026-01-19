using MemoryPack;
using System;
using System.Collections.Generic;
using UnityEngine;

[MemoryPackable]
[Serializable]
public partial class Deck
{
    public List<CardData> decklist;
    public List<CardData> extraDecklist;

    public Deck(List<CardData> decklist, List<CardData> extraDecklist)
    {
        this.decklist = decklist;
        this.extraDecklist = extraDecklist;
    }
}
