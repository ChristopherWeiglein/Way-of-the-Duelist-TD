using UnityEngine;
using System.Collections.Generic;

public class TowerTribute : MonoBehaviour
{
    [SerializeField] private TowerInfo towerInfo;
    private void OnMouseDown()
    {
        switch (GameManager.CurrentGameMode)
        {
            case GameManager.GameMode.TributeMode:
                if (TributeManager.instance.TryTribute((MonsterData)towerInfo.cardData))
                {
                    GraveyardCardFactory.instance.CreateGraveyardCard((MonsterData)towerInfo.cardData, new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.UsedAsTribute, CardDataTypes.CardTags.SentFromField });
                    Destroy(gameObject);
                }
                break;
            case GameManager.GameMode.FusionSummonMode:
                if (FusionManager.instance.TryUseAsFusionMaterial((MonsterData)towerInfo.cardData))
                {
                    GraveyardCardFactory.instance.CreateGraveyardCard((MonsterData)towerInfo.cardData, new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.UsedAsFusionMaterial, CardDataTypes.CardTags.SentFromField });
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }
}
