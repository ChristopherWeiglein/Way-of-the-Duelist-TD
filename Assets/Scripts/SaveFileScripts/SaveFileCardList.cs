using System.Collections.Generic;

public class SaveFileCardList
{
    public string[] cardList;
    public int[] cardListAmount;

    public SaveFileCardList(List<DeckEditorDataTypes> cardList)
    {
        this.cardList = new string[cardList.Count];
        this.cardListAmount = new int[cardList.Count];
        for (int i = 0; i < cardList.Count; i++)
        {
            this.cardList[i] = cardList[i].cardData.name;
            this.cardListAmount[i] = cardList[i].amount;
        }
    }
}
