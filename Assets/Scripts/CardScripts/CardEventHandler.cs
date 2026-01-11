using System.Collections.Generic;
using UnityEngine;

public class CardEventHandler : MonoBehaviour
{
    public delegate void SendToGrave(List<CardDataTypes.CardTags> cardTags);
    public event SendToGrave OnSendToGrave;

    public void CallOnSendToGrave(List<CardDataTypes.CardTags> cardTags)
    {
        OnSendToGrave?.Invoke(cardTags);
    }
}
