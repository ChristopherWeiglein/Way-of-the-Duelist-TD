using UnityEngine;
using System.Collections.Generic;

public class OnSpellActivation : MonoBehaviour
{
    private InfoRoot cardInfoManager;

    private void Start()
    {
        cardInfoManager = GetComponent<InfoRoot>();
    }

    private void ActivateCard()
    {
        if (!enabled)
            return;

        if(cardInfoManager.cardData.GetCardInfo().cardType == CardDataTypes.CardType.Spell)
        {
            GraveyardCardFactory.instance.CreateGraveyardCard(cardInfoManager.cardData, new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.ActivatedSpellCard });
            Destroy(gameObject);
        }
    }
}
