using UnityEngine;
using System;

public class CardFactory : MonoBehaviour
{
    public static CardFactory instance;
    [SerializeField] private GameObject cardPrefab;

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

    public void CreateCard(CardData cardData, Vector3 position, GameObject parent)
    {
        GameObject newCard = Instantiate(cardPrefab, position, parent.transform.rotation, parent.transform);
        newCard.GetComponent<SpriteRenderer>().sprite = cardData.GetCardInfo().sprite;
        newCard.GetComponent<CardInfoManager>().cardData = cardData;
        if (cardData.HasCardSpecificScript())
            newCard.AddComponent(Type.GetType(cardData.name));
    }
}
