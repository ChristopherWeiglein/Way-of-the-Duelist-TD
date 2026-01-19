using UnityEngine;

public class RemoveCardFromDeck : MonoBehaviour
{
    private InfoRoot cardInfo;

    private void Start()
    {
        cardInfo = GetComponent<InfoRoot>();
    }

    private void OnEnable()
    {
        GetComponent<UIClickHandler>().onRightClick.AddListener(RemoveThisCardToDeck);
    }

    private void OnDisable()
    {
        GetComponent<UIClickHandler>().onRightClick.RemoveListener(RemoveThisCardToDeck);
    }

    public void RemoveThisCardToDeck()
    {
        if (cardInfo.cardData == null)
            return;

        GameObject.Find("Deckboxes").GetComponent<MultiDeckHandler>().RemoveCardFromDeck(cardInfo.cardData);
        GameObject.Find("Box").GetComponent<BoxHandler>().AddCardToBox(cardInfo.cardData);
        Destroy(gameObject);
    }
}
