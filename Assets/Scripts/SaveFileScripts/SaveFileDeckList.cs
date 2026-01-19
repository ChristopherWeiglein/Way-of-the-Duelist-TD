using MemoryPack;
using System.Collections.Generic;


[System.Serializable]
[MemoryPackable]
public partial class SaveFileDeckList
{
    public List<DeckString> deckboxes;

    [MemoryPackConstructor]
    public SaveFileDeckList() { }

    public SaveFileDeckList(List<Deck> deckboxes)
    {
        this.deckboxes = new();
        foreach(Deck deck in deckboxes)
        {
            DeckString deckString = new DeckString() { decklist = new(), extradecklist = new() };
            foreach(CardData card in deck.decklist)
                deckString.decklist.Add(card.name);
            foreach(CardData card in deck.extraDecklist)
                deckString.extradecklist.Add(card.name);
            this.deckboxes.Add(deckString);
        }
    }
}
