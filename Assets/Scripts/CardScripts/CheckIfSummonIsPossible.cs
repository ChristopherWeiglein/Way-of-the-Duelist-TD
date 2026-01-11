using System.ComponentModel.Design;
using UnityEngine;

public class CheckIfSummonIsPossible : MonoBehaviour
{
    public CardInfoManager cardInfoManager;

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += IsSummonPossible;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= IsSummonPossible;
    }

    private void IsSummonPossible()
    {
        CardData cardData = cardInfoManager.cardData;

        if(cardData.GetCardInfo().cardType == CardDataTypes.CardType.Monster)
        {
            MonsterData monsterData = (MonsterData)cardData;
            cardInfoManager.SetSummonPossible(monsterData.GetMonsterInfo().tributeCost <= GameObject.Find("SummonedMonsters").transform.childCount && monsterData.GetMonsterInfo().tributeCost >= 0 && NormalSummonManager.instance.availableNormalSummons > 0);
        }
    }
}
