using UnityEngine;
using System;
using Unity.VisualScripting;

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
        switch (cardData.GetCardInfo().cardType)
        {
            case CardDataTypes.CardType.Monster:
                MonsterCardHandInfo monsterCardHandInfo = newCard.AddComponent<MonsterCardHandInfo>();
                monsterCardHandInfo.cardData = cardData;
                monsterCardHandInfo.cardInfo = cardData.GetCardInfo();
                monsterCardHandInfo.MonsterInfo = ConvertCardData.ToMonsterData(cardData).GetMonsterInfo();
                break;
            case CardDataTypes.CardType.Spell:
                SpellCardHandInfo spellCardHandInfo = newCard.AddComponent<SpellCardHandInfo>();
                spellCardHandInfo.cardData = cardData;
                spellCardHandInfo.cardInfo = cardData.GetCardInfo();
                break;
            case CardDataTypes.CardType.Trap:
                break;
            default: 
                break;
        }

        if (cardData.HasCardSpecificScript())
            newCard.AddComponent(Type.GetType(cardData.name));
    }
}
