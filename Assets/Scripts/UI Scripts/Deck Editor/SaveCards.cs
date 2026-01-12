using UnityEngine;

public class SaveCards : MonoBehaviour
{
    public void SaveCardLists()
    {
        SaveLoadHandler.SaveDeckList();
    }

    public void LoadCardLists()
    {
        SaveLoadHandler.LoadDeckList();
        foreach(CardData card in SaveLoadHandler.deckList)
        {
            Debug.Log(card.name);
        }
    }
}
