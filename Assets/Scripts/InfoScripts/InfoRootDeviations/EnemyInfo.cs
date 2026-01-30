using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : InfoRoot, IMonsterCard
{
    public CardDataTypes.MonsterInfo MonsterInfo {  get; set; }
    public List<EnemyDataTypes.EnemyStatus> activeStatuses;
    public delegate void EventMethod();
    public event EventMethod OnStatusReceived;

    public void GetStatus(EnemyDataTypes.EnemyStatus status)
    {
        if (activeStatuses.Contains(status))
            return;

        activeStatuses.Add(status);
        OnStatusReceived?.Invoke();
    }
}
