using UnityEngine;

public class SaveCards : MonoBehaviour
{
    public void SaveCardLists()
    {
        int decklistcount = GameObject.Find("Deck").GetComponent<DeckBoxHandler>().GetDeckList().Count;
        int extradecklistcount = GameObject.Find("ExtraDeck").GetComponent<ExtraDeckBoxHandler>().GetExtraDeckList().Count;
        if (decklistcount < 40)
        {
            GameObject.Find("Message").GetComponent<MessageHandler>().ShowMessageForSeconds("Deck size too low", 3);
            return;
        }

        SaveLoadHandler.SaveDeckList();
    }
}
