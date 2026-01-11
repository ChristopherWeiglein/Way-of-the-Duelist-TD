using System.Collections;
using UnityEngine;

public class NormalSummonManager : MonoBehaviour
{
    public static NormalSummonManager instance;
    public int availableNormalSummons { get; private set; } = 1;
    public int normalSummonsPerTurn = 1;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        GameManager.OnTurnStart += OnTurnStart;
    }

    private void OnDisable()
    {
        GameManager.OnTurnStart -= OnTurnStart;
    }

    private void OnTurnStart()
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
