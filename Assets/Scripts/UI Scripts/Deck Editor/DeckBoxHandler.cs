using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DeckBoxHandler : MonoBehaviour
{
    private List<CardData> deckList = new();


    public void InstantiateDeck()
    {
        if(transform.childCount >  0)
            BroadcastMessage("Destroy");
        SaveLoadHandler.LoadAllDeckLists();
        deckList = SaveLoadHandler.deckBoxes[0].decklist;
        ShowDeckList();
        RemoveCardsFromBox();
    }

    private void RemoveCardsFromBox()
    {
        foreach(CardData card in deckList)
        {
            if (!GameObject.Find("Box").GetComponent<BoxHandler>().TryGetCardFromBox(card))
                Debug.Log(card.name + " not found!");
        }
    }

    private void ShowDeckList()
    {
        deckList = deckList.OrderBy(card => card.GetCardInfo().cardName).ToList();
        foreach (CardData card in deckList)
        {
            DeckEditorCardFactory.instance.CreateDeckEditorCard(card, transform);
        }
    }

    public bool TryAddCardToDeck(CardData cardData)
    {
        if (cardData is ExtraDeckMonsterData)
            return transform.parent.GetComponentInChildren<ExtraDeckBoxHandler>().TryAddCardToDeck(cardData);
        if (deckList.FindAll(card => card.GetCardInfo().cardName == cardData.GetCardInfo().cardName).Count >= 3 || deckList.Count >= 60)
            return false;

        if(!GameObject.Find("Box").GetComponent<BoxHandler>().TryGetCardFromBox(cardData))
            return false;

        deckList.Add(cardData);
        DeckEditorCardFactory.instance.CreateDeckEditorCard(cardData, transform);

        return true;
    }

    public void RemoveCardFromDeck(CardData cardData)
    {
        if(cardData is ExtraDeckMonsterData)
        {
            transform.parent.GetComponentInChildren<ExtraDeckBoxHandler>().RemoveCardFromExtraDeck(cardData);
            return;
        }

        deckList.Remove(deckList.Find(card => card.name == cardData.name));
    }

    public List<CardData> GetDeckList() => deckList;
}
