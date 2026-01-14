using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckBoxHandler : MonoBehaviour
{
    private List<CardData> deckList = new();

    public void InstantiateDeck()
    {
        if(transform.childCount >  0)
            BroadcastMessage("Destroy");
        SaveLoadHandler.LoadDeckList();
        deckList = SaveLoadHandler.deckList;
        ShowDeckList();
        RemoveCardsFromBox();
    }

    private void RemoveCardsFromBox()
    {
        BoxHandler boxHandler = GameObject.Find("Box").GetComponent<BoxHandler>();
        foreach(CardData card in deckList)
        {
            if (!boxHandler.TryGetCardFromBox(card))
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
        if (deckList.FindAll(card => card.GetCardInfo().cardName == cardData.GetCardInfo().cardName).Count >= 3)
            return false;

        if(cardData is ExtraDeckMonsterData)
            return GameObject.Find("ExtraDeck").GetComponent<ExtraDeckBoxHandler>().TryAddCardToDeck(cardData);

        if(!GameObject.Find("Box").GetComponent<BoxHandler>().TryGetCardFromBox(cardData))
            return false;

        deckList.Add(cardData);
        DeckEditorCardFactory.instance.CreateDeckEditorCard(cardData, transform);

        return true;
    }

    public void RemoveCardFromDeck(CardData cardData)
    {
        deckList.Remove(deckList.Find(card => card.name == cardData.name));
    }

    public List<CardData> GetDeckList() => deckList;
}
