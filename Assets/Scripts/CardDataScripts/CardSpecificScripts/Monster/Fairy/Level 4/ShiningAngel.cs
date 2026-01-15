using System.Collections.Generic;
using UnityEngine;

public class ShiningAngel : MonoBehaviour
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
        if (cardTags.Contains(CardDataTypes.CardTags.DestroyedByBattle))
        {
            ChainManager.instance.AddChainLink(SpecialSummonFromDeck, GetComponent<InfoRoot>().cardData);
        }
    }

    private void SpecialSummonFromDeck()
    {
        DeckManager.instance.SummonMonsterFromDeck(monster => monster.GetMonsterInfo().attack <= 1500 && monster.GetMonsterInfo().attribute == CardDataTypes.MonsterAttribute.Light);
    }
}
