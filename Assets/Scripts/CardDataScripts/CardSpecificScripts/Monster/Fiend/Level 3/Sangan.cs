using System.Collections.Generic;
using UnityEngine;

public class Sangan : MonoBehaviour
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
            ChainManager.instance.AddChainLink(TutorCard, GetComponent<InfoRoot>().cardData);
        }
    }
    
    private void TutorCard()
    {
        DeckManager.instance.AddMonsterFromDeckToHand(monster => monster.GetMonsterInfo().attack <= 1500);
    }
}
