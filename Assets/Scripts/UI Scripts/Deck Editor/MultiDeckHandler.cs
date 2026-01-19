using UnityEngine;
using System.Collections.Generic;

public class MultiDeckHandler : MonoBehaviour
{
    [SerializeField] private List<Deck> decks;
    public int activedeckslot = 1;
    private const int maxExtradeckCount = 15;
    private const int maxDeckCount = 60;
    private DeckBoxHandler currentDeckHandler;
    private ExtraDeckBoxHandler currentExtradeckHandler;


    public void ChangeActiveDeckSlot(int activedeckslot)
    {
        this.activedeckslot = activedeckslot;
        currentDeckHandler = transform.GetChild(activedeckslot).GetComponentInChildren<DeckBoxHandler>();
        currentDeckHandler.InstantiateDeck(decks[activedeckslot - 1].decklist);
        currentExtradeckHandler = transform.GetChild(activedeckslot).GetComponentInChildren<ExtraDeckBoxHandler>();
        currentExtradeckHandler.InstantiateExtraDeck(decks[activedeckslot - 1].extraDecklist);
    }

    public void InstantiateDeckbox()
    {
        SaveLoadHandler.LoadAllDeckLists();
        decks = SaveLoadHandler.deckBoxes;
        RemoveCardsFromBox();
        currentDeckHandler = transform.GetChild(activedeckslot).GetComponentInChildren<DeckBoxHandler>();
        currentDeckHandler.InstantiateDeck(decks[activedeckslot - 1].decklist);
        currentExtradeckHandler = transform.GetChild(activedeckslot).GetComponentInChildren<ExtraDeckBoxHandler>();
        currentExtradeckHandler.InstantiateExtraDeck(decks[activedeckslot - 1].extraDecklist);
    }

    private void RemoveCardsFromBox()
    {
        foreach(Deck deck in decks)
        {
            foreach(CardData card in deck.decklist)
            {
                if (!GameObject.Find("Box").GetComponent<BoxHandler>().TryGetCardFromBox(card))
                    Debug.Log(card.name + " not found!");
            }
            foreach(CardData card in deck.extraDecklist)
            {
                if (!GameObject.Find("Box").GetComponent<BoxHandler>().TryGetCardFromBox(card))
                    Debug.Log(card.name + " not found!");
            }
        }
    }

    public void RemoveCardFromDeck(CardData cardData)
    {
        if(cardData is ExtraDeckMonsterData)
        {
            decks[activedeckslot - 1].extraDecklist.Remove(decks[activedeckslot - 1].extraDecklist.Find(card => card.name == cardData.name));
        }
        else
        {
            decks[activedeckslot - 1].decklist.Remove(decks[activedeckslot - 1].decklist.Find(card => card.name == cardData.name));
        }
    }

    public bool TryAddCardToDeck(CardData cardData)
    {
        int amountOfCardsInAllDecks = 0;
        if (cardData is ExtraDeckMonsterData)
        {
            if (decks[activedeckslot - 1].extraDecklist.Count >= maxExtradeckCount)
                return false;
            
            foreach(Deck deck in decks)
                amountOfCardsInAllDecks += deck.extraDecklist.FindAll(card => card.GetCardInfo().cardName == cardData.GetCardInfo().cardName).Count;
            if (amountOfCardsInAllDecks >= 3)
                return false;
            if(!GameObject.Find("Box").GetComponent<BoxHandler>().TryGetCardFromBox(cardData))
                return false;

            decks[activedeckslot - 1].extraDecklist.Add(cardData);
            DeckEditorCardFactory.instance.CreateDeckEditorCard(cardData, currentExtradeckHandler.transform);
            return true;
        }
        else
        {
            if (decks[activedeckslot - 1].decklist.Count >= maxDeckCount)
                return false;
            foreach (Deck deck in decks)
                amountOfCardsInAllDecks += deck.decklist.FindAll(card => card.GetCardInfo().cardName == cardData.GetCardInfo().cardName).Count;
            if (amountOfCardsInAllDecks >= 3)
                return false;
            if (!GameObject.Find("Box").GetComponent<BoxHandler>().TryGetCardFromBox(cardData))
                return false;

            decks[activedeckslot - 1].decklist.Add(cardData);
            DeckEditorCardFactory.instance.CreateDeckEditorCard(cardData, currentDeckHandler.transform);
            return true;
        }

    }

    public List<Deck> GetDecklists() => decks;

    public void NewDeckSlotAdded()
    {
        decks.Add(new(new(),new()));
    }
}
