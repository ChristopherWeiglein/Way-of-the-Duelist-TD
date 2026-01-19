using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using static DeckEditorDataTypes;

public class DeckEditorCardFactory : MonoBehaviour
{
    public static DeckEditorCardFactory instance;
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

    public void CreateDeckEditorCard(CardData cardData, Transform parent)
    {
        GameObject newCard = Instantiate(cardPrefab, parent.position, Quaternion.identity, parent);
        newCard.GetComponent<Image>().sprite = cardData.GetCardInfo().sprite;
        newCard.GetComponent<InfoRoot>().cardData = cardData;
        newCard.GetComponent<InfoRoot>().cardInfo = cardData.GetCardInfo();
        newCard.AddComponent<DestroyCards>();

        switch (parent.name.Substring(0,3))
        {
            case "Box":
                newCard.AddComponent<AddCardToDeck>();
                newCard.AddComponent<ShowCardAmountInBox>();
                break;
            case "Dec":
            case "Ext":
                newCard.AddComponent<RemoveCardFromDeck>();
                break;
            case "Pul":               
                break;
            default:
                break;
        }
    }
}
