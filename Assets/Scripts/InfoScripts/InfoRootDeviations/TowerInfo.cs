using System.Collections;
using UnityEngine;

public class TowerInfo : InfoRoot, IMonsterCard
{
    public CardDataTypes.MonsterInfo MonsterInfo { get; set; }
    public static float baseRange = 50f;


    private void Start()
    {
        StartCoroutine(WaitForMonsterInfo());
    }

    private IEnumerator WaitForMonsterInfo()
    {
        while(MonsterInfo.level == 0)
            yield return null;
        float range = baseRange/2 + baseRange * MonsterInfo.level / 8;
        transform.Find("Range").localScale = new Vector3(range, range, range);
    }
}
