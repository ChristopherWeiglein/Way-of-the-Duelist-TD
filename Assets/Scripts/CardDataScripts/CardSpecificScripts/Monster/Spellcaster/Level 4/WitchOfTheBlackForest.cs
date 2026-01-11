using System.Collections.Generic;
using UnityEngine;

public class WitchOfTheBlackForest : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<CardEventHandler>().OnSendToGrave += OnSendToGrave;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<CardEventHandler>().OnSendToGrave -= OnSendToGrave;
    }

    private void OnSendToGrave(List<CardDataTypes.CardTags> cardTags)
    {
        if (cardTags.Contains(CardDataTypes.CardTags.SentFromField))
        {
            ChainManager.instance.AddChainLink(TutorCard);
        }
    }

    private void TutorCard()
    {
        DeckManager.instance.AddMonsterFromDeckToHand(monster => monster.GetMonsterInfo().defense <= 1500);
    }
}
