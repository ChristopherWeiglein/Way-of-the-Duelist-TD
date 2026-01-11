using UnityEngine;
using System.Collections.Generic;

public class OnSpellActivation : MonoBehaviour
{
    [SerializeField] private CardInfoManager cardInfoManager;

    private void ActivateCard()
    {
        if(cardInfoManager.cardData.GetCardInfo().cardType == CardDataTypes.CardType.Spell)
        {
            GraveyardCardFactory.instance.CreateGraveyardCard(cardInfoManager.cardData, new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.ActivatedSpellCard });
            Destroy(gameObject);
        }
    }
}
