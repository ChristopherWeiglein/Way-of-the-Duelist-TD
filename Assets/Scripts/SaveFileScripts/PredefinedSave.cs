using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PredefinedSave", menuName = "Scriptable Objects/PredefinedSave")]
public class PredefinedSave : ScriptableObject
{
    [SerializeField] private List<DeckEditorDataTypes> cardList;
    [SerializeField] private List<CardData> deckList;
    [SerializeField] private List<CardData> extraDeckList;
    [SerializeField] private int starchips;
    [SerializeField] private int[] records;

    public List<DeckEditorDataTypes> GetCardList() => cardList;
    public List<CardData> GetDeckList() => deckList;
    public List<CardData> GetExtraDeckList() => extraDeckList;
    public int GetStarChips() => starchips;
    public int[] GetRecords() => records;
}
