using System.Collections.Generic;
using UnityEngine;
using System;

public class GraveyardCardFactory : MonoBehaviour
{
    public static GraveyardCardFactory instance;
    [SerializeField] private GameObject graveyardCardPrefab;

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

    public void CreateGraveyardCard(CardData cardData, List<CardDataTypes.CardTags> tagList)
    {
        GameObject newCard = Instantiate(graveyardCardPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        newCard.GetComponent<GraveyardCardInfo>().cardData = cardData;
        newCard.GetComponent<GraveyardCardInfo>().cardTags = tagList;
        newCard.GetComponent<SpriteRenderer>().sprite = cardData.GetCardInfo().sprite;
        if (cardData.HasCardSpecificScript())
            newCard.AddComponent(Type.GetType(cardData.name));
        newCard.GetComponent<CardEventHandler>().CallOnSendToGrave(tagList);
        GameManager.CardSentToGrave();
    }
}
