using UnityEngine;

public class RedEyesDarkDragoon : MonoBehaviour
{
    private TowerInfo towerInfo;
    private int buffValue = 0;
    private const int buffIncrease = 100;


    private void Start()
    {
        towerInfo = gameObject.GetComponent<TowerInfo>();
        towerInfo.onTargetHit += OnTargetHit;
    }

    private void OnTargetHit(GameObject target)
    {
        EnemyInfo targetInfo = target.GetComponent<EnemyInfo>();
        targetInfo.GetStatus(EnemyDataTypes.EnemyStatus.Destroyed);
        targetInfo.GetStatus(EnemyDataTypes.EnemyStatus.Negated);
        buffValue += buffIncrease;
        towerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Attack, buffValue));
    }
}
