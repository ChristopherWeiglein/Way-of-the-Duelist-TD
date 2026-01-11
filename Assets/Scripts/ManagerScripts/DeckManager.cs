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
        }
        foreach (CardData card in cardsforDeck)
        {
            for (int i = 0; i < 3; i++)
            {
                deck.Add(card);
            }
        }
        ShuffleDeck();
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
        OptionsManager.instance.ShowOptions(monsterList.OfType<CardData>().ToList());
        while(OptionsManager.instance.selectedCard == null)
            yield return null;
        CardFactory.instance.CreateCard(OptionsManager.instance.selectedCard, gameObject.transform.position, hand);
        deck.Remove(deck.Find(card => card.GetCardInfo().cardName == OptionsManager.instance.selectedCard.GetCardInfo().cardName));
        GameManager.OnCardAddedToHand();
    }

    private void ShowDeckSize()
    {
        text.text = deck.Count.ToString();
    }
}
