using UnityEngine;
using System.Collections.Generic;

public class TowerTribute : MonoBehaviour
{
    [SerializeField] private InfoRoot towerInfo;
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
            default:
                break;
        }
    }
}
