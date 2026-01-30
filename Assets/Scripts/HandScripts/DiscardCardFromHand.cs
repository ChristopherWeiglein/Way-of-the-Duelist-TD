using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

public class DiscardCardFromHand : MonoBehaviour
{
    public bool costPayed = false;

    public void DiscardCardForCost(int numberOfCards, Predicate<LocationDataTypes.CardLocationData> condition)
    {
        costPayed = false;
        StartCoroutine(DiscardSequence(numberOfCards, condition, new List<CardDataTypes.CardTags> { CardDataTypes.CardTags.SentAsCost, CardDataTypes.CardTags.SentFromHand}));
    }

    private IEnumerator DiscardSequence(int numberOfCards, Predicate<LocationDataTypes.CardLocationData> condition, List<CardDataTypes.CardTags> cardTags)
    {
        for(int i = 0; i < numberOfCards; i++)
        {
            List<LocationDataTypes.CardLocationData> cardsInHand = HandManager.instance.GetCardsInHand();
            OptionsManager.instance.ShowOptions(cardsInHand.FindAll(condition));
            while (OptionsManager.instance.SelectedCard.cardData == null)
                yield return null;
            GraveyardCardFactory.instance.CreateGraveyardCard(OptionsManager.instance.SelectedCard.cardData, cardTags);
            Destroy(OptionsManager.instance.SelectedCard.correlatingGameObject);
        }
        costPayed = true;
    } 

    public void DiscardCardForEffect(int numberOfCards, Predicate<LocationDataTypes.CardLocationData> condition)
    {
        StartCoroutine(DiscardSequence(numberOfCards, condition, new List<CardDataTypes.CardTags> { CardDataTypes.CardTags.SentFromHand }));
    }
}
