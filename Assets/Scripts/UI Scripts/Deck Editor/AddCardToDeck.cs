using UnityEngine;

public class AddCardToDeck : MonoBehaviour
{
    private InfoRoot cardInfo;

    private void Start()
    {
        cardInfo = GetComponent<InfoRoot>();
    }

    private void OnEnable()
    {
        GetComponent<UIClickHandler>().onRightClick.AddListener(AddThisCardToDeck);
    }

    private void OnDisable()
    {
        GetComponent<UIClickHandler>().onRightClick.RemoveListener(AddThisCardToDeck);
    }

    public void AddThisCardToDeck()
    {
        if (cardInfo.cardData == null)
            return;

        GameObject.Find("Deckboxes").GetComponent<MultiDeckHandler>().TryAddCardToDeck(cardInfo.cardData);
    }
}
