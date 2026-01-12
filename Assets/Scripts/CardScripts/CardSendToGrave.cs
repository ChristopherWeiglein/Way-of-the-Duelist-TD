using System.Collections.Generic;
using UnityEngine;

public class CardSendToGrave : MonoBehaviour
{
    public void SendToGrave(List<CardDataTypes.CardTags> cardTags)
    {
        GraveyardCardFactory.instance.CreateGraveyardCard(GetComponent<InfoRoot>().cardData, cardTags);
        Destroy(gameObject);
    }
}
