using System.Collections;
using UnityEngine;

public class NormalSummonManager : MonoBehaviour
{
    public int availableNormalSummons { get; private set; } = 1;
    public int normalSummonsPerTurn = 1;

    private void OnEnable()
    {
        GameManager.OnTurnStart += IncreaseNormalSummon;
    }

    private void OnDisable()
    {
        GameManager.OnTurnStart -= IncreaseNormalSummon;
    }

    public void IncreaseNormalSummon()
    {
        availableNormalSummons = normalSummonsPerTurn;
        GameManager.NormalSummonsIncreased();
    }

    public void NormalSummonMonster(MonsterData cardData)
    {
        StartCoroutine(NormalSummonSequence(cardData));
    }

    private IEnumerator NormalSummonSequence(MonsterData cardData)
    {
        TributeManager.instance.SetTributeCost(cardData);
        while(TributeManager.instance.remainingTributeCost > 0)
            yield return null;

        SummonManager.instance.SummonMonster(cardData);
        availableNormalSummons--;
    }

}
