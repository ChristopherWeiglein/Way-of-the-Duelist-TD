using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using TMPro;
using System.Collections;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;
    public List<CardData> deck { get; private set; } = new();
    [SerializeField] private List<CardData> cardsforDeck;
    [SerializeField] private GameObject hand;
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            SaveLoadHandler.LoadDeckList();
            deck = SaveLoadHandler.deckList;
            ShuffleDeck();
        }
        
    }

    private void ShuffleDeck()
    {
        deck = deck.OrderBy(i => Guid.NewGuid()).ToList();
    }

    public void DrawCardsFromDeck(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (deck.Count <= 0)
            {
                GameOverManager.GameOver();
                return;
            }              
            CardFactory.instance.CreateCard(deck[0], gameObject.transform.position, hand);
            deck.RemoveAt(0);
        }
        GameManager.CardDrawn();
        ShowDeckSize();
    }

    public void AddMonsterFromDeckToHand(Predicate<MonsterData> condition)
    {
        List<MonsterData> monsterList = new();

        foreach (CardData card in deck)
        {
            if (card.GetCardInfo().cardType == CardDataTypes.CardType.Monster)
                monsterList.Add((MonsterData)card);
        }
        monsterList = monsterList.FindAll(condition);
        if (monsterList.Count == 0)
        {
            TextMessageManager.instance.ShowMessageForSeconds("No legal target available", 2);
            return;
        }

        StartCoroutine(TutorSequence(monsterList));
    }

    private IEnumerator TutorSequence(List<MonsterData> monsterList)
    {
        OptionsManager.instance.ShowOptions(CardLocationPairFactory.AddLocationsToList(monsterList.OfType<CardData>().ToList(), LocationDataTypes.CardLocation.Deck));
        while(OptionsManager.instance.SelectedCard.cardData == null)
            yield return null;
        CardFactory.instance.CreateCard(OptionsManager.instance.SelectedCard.cardData, gameObject.transform.position, hand);
        deck.Remove(deck.Find(card => card.GetCardInfo().cardName == OptionsManager.instance.SelectedCard.cardData.GetCardInfo().cardName));
        GameManager.OnCardAddedToHand();
    }

    private void ShowDeckSize()
    {
        text.text = deck.Count.ToString();
    }

    public void SendCardToGrave(CardData cardData, List<CardDataTypes.CardTags> graveTags)
    {
        deck.Remove(deck.Find(card => card.GetCardInfo().cardName == cardData.GetCardInfo().cardName));
        ShuffleDeck();
        GraveyardCardFactory.instance.CreateGraveyardCard(cardData, graveTags);
    }

    public List<LocationDataTypes.CardLocationData> GetDeckCardList() => CardLocationPairFactory.AddLocationsToList(deck, LocationDataTypes.CardLocation.Deck);

}
