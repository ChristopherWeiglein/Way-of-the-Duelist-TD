using System.Collections.Generic;
using UnityEngine;

public class SaveCards : MonoBehaviour
{
    private const int minDeckSize = 40;

    public void SaveCardLists()
    {
        List<Deck> decklists = GameObject.Find("Deckboxes").GetComponent<MultiDeckHandler>().GetDecklists();
        
        foreach(Deck deck in decklists)
        {
            if (deck.decklist.Count < minDeckSize)
            {
                GameObject.Find("Message").GetComponent<MessageHandler>().ShowMessageForSeconds("At least one of your Decks is below 40 cards.\n Decks were not safed", 3);
                return;
            }
        }

        SaveLoadHandler.SaveDeckList(decklists);
        GameObject.Find("Deckboxes").GetComponent<DeckEditorUnlockHandler>().SaveProfile();
    }
}
