using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PredefinedSave", menuName = "Scriptable Objects/PredefinedSave")]
public class PredefinedSave : ScriptableObject
{
    [SerializeField] private List<DeckEditorDataTypes> cardList;
    [SerializeField] private List<CardData> deckList;
    [SerializeField] private List<CardData> extraDeckList;

    public List<DeckEditorDataTypes> GetCardList() => cardList;
    public List<CardData> GetDeckList() => deckList;
    public List<CardData> GetExtraDeckList() => extraDeckList;
}
