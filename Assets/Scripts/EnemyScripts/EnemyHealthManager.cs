using Unity.Mathematics;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    [SerializeField] private HealthBarBehaviour healthBarBehaviour;
    [SerializeField] private EnemyInfo enemyStats;

    private void Start()
    {

        health = (int)(enemyStats.monsterInfo.defense * math.pow(1.1, SpawnManager.instance.WaveNumber));
        healthBarBehaviour.SetMaxHealth(health);
    }

    private void Update()
    {
        healthBarBehaviour.SetHealth(health);
    }
}
