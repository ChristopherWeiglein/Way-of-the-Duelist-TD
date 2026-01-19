using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BoxHandler : MonoBehaviour
{
    [SerializeField] private List<DeckEditorDataTypes> cardList;

    public delegate void EventMethod();
    public static event EventMethod OnCardsShown;
    public static event EventMethod OnAmountChanged;

    private string deckBoxNumber = "1";
   

    private void OnEnable()
    {
        if(transform.childCount > 0)
            BroadcastMessage("Destroy");
        SaveLoadHandler.LoadCardList();
        cardList = SaveLoadHandler.cardList;
        ShowCardList();
        OnAmountChanged?.Invoke();
        GameObject.Find("Deck" + deckBoxNumber).GetComponent<DeckBoxHandler>().InstantiateDeck();
        GameObject.Find("ExtraDeck" + deckBoxNumber).GetComponent<ExtraDeckBoxHandler>().InstantiateExtraDeck();
    }

    private void ShowCardList()
    {
        cardList = cardList.OrderBy(card => card.cardData.GetCardInfo().cardType).ToList();
        foreach (DeckEditorDataTypes element in cardList)
        {
            DeckEditorCardFactory.instance.CreateDeckEditorCard(element.cardData, transform);
        }
        OnCardsShown?.Invoke();
    }

    public bool TryGetCardFromBox(CardData cardData)
    {
        if(cardList.Find(card => card.cardData.name == cardData.name).amount <= 0)
            return false;

        cardList.Find(card => card.cardData.name == cardData.name).amount--;
        OnAmountChanged?.Invoke();
        return true;
    }

    public void AddCardToBox(CardData cardData)
    {
        cardList.Find(card => card.cardData.name == cardData.name).amount++;
        OnAmountChanged?.Invoke();
    }

    public List<DeckEditorDataTypes> GetCardList() => cardList;

    public int GetCardAmountInBox(CardData cardData) => cardList.Find(card => card.cardData.name == cardData.name).amount;

    public void SetDeckBoxNumber(string deckBoxNumber)
    {
        this.deckBoxNumber = deckBoxNumber;
    }
}
