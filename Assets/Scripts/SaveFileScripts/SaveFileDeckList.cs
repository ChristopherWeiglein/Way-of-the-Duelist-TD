using System.Collections.Generic;

[System.Serializable]
public class SaveFileDeckList
{
    public string[] deckList;
    public string[] extraDeckList;

    public SaveFileDeckList(List<CardData> deckList, List<CardData> extraDeckList)
    {
        this.deckList = new string[deckList.Count];
        for(int i = 0;i < deckList.Count; i++)
        {
            this.deckList[i] = deckList[i].name;
        }

        this.extraDeckList = new string[extraDeckList.Count];
        for(int i = 0; i < extraDeckList.Count; i++)
        {
            this.extraDeckList[i] = extraDeckList[i].name;
        }
    }
}
