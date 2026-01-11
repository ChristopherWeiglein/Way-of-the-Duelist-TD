using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseAsFusionMaterial : MonoBehaviour
{
    private MonsterCardHandInfo cardInfoManager;

    private void Start()
    {
        cardInfoManager = GetComponent<IMonsterCard>() as MonsterCardHandInfo;
    }

    private void OnMouseDown()
    {
        if (cardInfoManager.cardData.GetCardInfo().cardType != CardDataTypes.CardType.Monster)
            return;

        if (FusionManager.instance.TryUseAsFusionMaterial((MonsterData)cardInfoManager.cardData))
        {
            GraveyardCardFactory.instance.CreateGraveyardCard((MonsterData)cardInfoManager.cardData, new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.UsedAsFusionMaterial });
            Destroy(gameObject);
        }
    }
}
