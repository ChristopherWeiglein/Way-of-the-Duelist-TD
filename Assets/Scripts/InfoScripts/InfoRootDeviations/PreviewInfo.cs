using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PreviewInfo : InfoRoot, IMonsterCard
{
    public CardDataTypes.MonsterInfo MonsterInfo { get; set; }
    public int health { get; private set; }
    public float speed { get; private set; }

    public void CalculateStats()
    {
        health = (int)((MonsterInfo.defense + 100) * Mathf.Pow(EnemyHealthManager.EnemyHealthMultiplierPerWave, SpawnManager.instance.WaveNumber));
        speed = Mathf.Pow(2f, 1000f / ((float)MonsterInfo.defense + 100f)) / 2;
    }

}
