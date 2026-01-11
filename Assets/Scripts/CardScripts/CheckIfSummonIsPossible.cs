using System.ComponentModel.Design;
using UnityEngine;

public class CheckIfSummonIsPossible : MonoBehaviour
{
    private IHandCard cardInfoManager;

    private void Start()
    {
        cardInfoManager = GetComponent<IHandCard>();
    }

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += IsNormalSummonPossible;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= IsNormalSummonPossible;
    }

    private void IsNormalSummonPossible()
    {
        cardInfoManager = GetComponent<IHandCard>();
        InfoRoot infoRoot = (InfoRoot)cardInfoManager;
        CardData cardData = infoRoot.cardData;

        if(cardData.GetCardInfo().cardType == CardDataTypes.CardType.Monster)
        {
            MonsterData monsterData = (MonsterData)cardData;
            cardInfoManager.SetNormalSummonPossible(monsterData.GetMonsterInfo().tributeCost <= GameObject.Find("SummonedMonsters").transform.childCount && monsterData.GetMonsterInfo().tributeCost >= 0 && NormalSummonManager.instance.availableNormalSummons > 0);
        }
    }
}
