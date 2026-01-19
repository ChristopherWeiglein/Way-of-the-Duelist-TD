using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PredefinedSave", menuName = "Scriptable Objects/PredefinedSave")]
public class PredefinedSave : ScriptableObject
{
    [SerializeField] private List<DeckEditorDataTypes> cardList;
    [SerializeField] private List<Deck> decks;
    [SerializeField] private int starchips;
    [SerializeField] private int[] records;
    [SerializeField] private int unlockedDeckslots;

    public List<DeckEditorDataTypes> GetCardList() => cardList;
    public List<Deck> GetDecks()
    {
        List<Deck> deckboxes = new List<Deck>();
        foreach(Deck deck in decks)
        {
            deckboxes.Add(new Deck(new List<CardData>(deck.decklist), new List<CardData>(deck.extraDecklist)));
        }
        return deckboxes;
    }
    public int GetStarChips() => starchips;
    public int[] GetRecords() => records;
    public int GetUnlockedDeckslots() => unlockedDeckslots;
}
