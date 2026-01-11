using UnityEngine;

public class CardSelection : MonoBehaviour
{
    private InfoRoot cardInfoManager;

    private void Start()
    {
        cardInfoManager = GetComponent<InfoRoot>();
    }

    private void OnMouseDown()
    {
        OptionsManager.instance.SelectCard(new LocationDataTypes.CardLocationData {gameObject = gameObject, cardData = cardInfoManager.cardData, cardLocation = gameObject.GetComponent<CardLocationUIManager>().cardLocation });
        transform.parent.BroadcastMessage("DestroyCard");
    }

    private void DestroyCard()
    {
        Destroy(gameObject);
    }
}
