using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExtraDeckBoxHandler : MonoBehaviour
{
    private List<CardData> extraDeckList;

    public void InstantiateExtraDeck()
    {
        if(transform.childCount > 0)
            BroadcastMessage("Destroy");
        SaveLoadHandler.LoadAllDeckLists();
        extraDeckList = SaveLoadHandler.deckBoxes[0].extraDecklist;
        ShowDeckList();
        RemoveCardsFromBox();
    }

    private void RemoveCardsFromBox()
    {
        BoxHandler boxHandler = GameObject.Find("Box").GetComponent<BoxHandler>();
        foreach (CardData card in extraDeckList)
        {
            if (!boxHandler.TryGetCardFromBox(card))
                Debug.Log(card.name + " not found!");
        }
    }

    private void ShowDeckList()
    {
        extraDeckList = extraDeckList.OrderBy(card => card.GetCardInfo().cardName).ToList();
        foreach (CardData card in extraDeckList)
        {
            DeckEditorCardFactory.instance.CreateDeckEditorCard(card, transform);
        }
    }

    public bool TryAddCardToDeck(CardData cardData)
    {
        if (extraDeckList.FindAll(card => card.GetCardInfo().cardName == cardData.GetCardInfo().cardName).Count >= 3 || extraDeckList.Count >= 15)
            return false;

        if (!GameObject.Find("Box").GetComponent<BoxHandler>().TryGetCardFromBox(cardData))
            return false;

        extraDeckList.Add(cardData);
        DeckEditorCardFactory.instance.CreateDeckEditorCard(cardData, transform);

        return true;
    }

    public void RemoveCardFromExtraDeck(CardData cardData)
    {
        extraDeckList.Remove(extraDeckList.Find(card => card.name == cardData.name));
    }

    public List<CardData> GetExtraDeckList() => extraDeckList;
}
