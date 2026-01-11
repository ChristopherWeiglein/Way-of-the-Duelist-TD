using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;

    private const int startingHandSize = 5;
    private int cardsDrawnPerTurn = 1;

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
    }

    private void Start()
    {
        DeckManager.instance.DrawCardsFromDeck(startingHandSize);
    }

    private void OnEnable()
    {
        GameManager.OnTurnStart += DrawForTurn;
    }

    private void OnDisable()
    {
        GameManager.OnTurnStart -= DrawForTurn;
    }

    private void DrawForTurn()
    {
        DeckManager.instance.DrawCardsFromDeck(cardsDrawnPerTurn);
    }
}
