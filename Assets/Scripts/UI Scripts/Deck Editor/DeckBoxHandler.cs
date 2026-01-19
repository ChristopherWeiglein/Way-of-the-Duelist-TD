using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DeckBoxHandler : MonoBehaviour
{
    private List<CardData> deckList = new();


    public void InstantiateDeck(List<CardData> decklist)
    {
        if(transform.childCount >  0)
            BroadcastMessage("Destroy");
        deckList = decklist;
        ShowDeckList();
    }

    private void ShowDeckList()
    {
        deckList = deckList.OrderBy(card => card.GetCardInfo().cardName).ToList();
        foreach (CardData card in deckList)
        {
            DeckEditorCardFactory.instance.CreateDeckEditorCard(card, transform);
        }
    }
}
