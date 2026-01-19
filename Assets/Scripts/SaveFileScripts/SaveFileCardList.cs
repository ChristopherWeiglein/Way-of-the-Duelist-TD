using MemoryPack;
using System.Collections.Generic;

[System.Serializable]
[MemoryPackable]
public partial class SaveFileCardList
{
    public List<StringIntPair> cardList;

    [MemoryPackConstructor]
    public SaveFileCardList()
    {

    }

    public SaveFileCardList(List<DeckEditorDataTypes> cardList)
    {
        this.cardList = new();
        foreach(DeckEditorDataTypes deckEditorData in cardList)
        {
            this.cardList.Add(new StringIntPair() { text = deckEditorData.cardData.name, number = deckEditorData.amount });
        }
    }
}
