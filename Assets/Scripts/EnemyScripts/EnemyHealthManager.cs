using Unity.Mathematics;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    [SerializeField] private HealthBarBehaviour healthBarBehaviour;
    [SerializeField] private EnemyInfo enemyStats;
    public static readonly float EnemyHealthMultiplierPerWave = 1.1f;

    private void Start()
    {

        health = (int)((enemyStats.MonsterInfo.defense + 100) * math.pow(EnemyHealthMultiplierPerWave, SpawnManager.instance.WaveNumber));
        healthBarBehaviour.SetMaxHealth(health);
    }

    private void Update()
    {
        healthBarBehaviour.SetHealth(health);
    }
}
