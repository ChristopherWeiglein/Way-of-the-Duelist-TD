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

        health = (int)((enemyStats.MonsterInfo.defense != 0 ? enemyStats.MonsterInfo.defense : 100) * math.pow(EnemyHealthMultiplierPerWave, SpawnManager.instance.WaveNumber));
        healthBarBehaviour.SetMaxHealth(health);
    }

    private void Update()
    {
        healthBarBehaviour.SetHealth(health);
    }

    public void ChangeHealth(int change)
    {
        health += (Mathf.Abs(change) > 0 ? change : -1) * (enemyStats.activeStatuses.Contains(EnemyDataTypes.EnemyStatus.Destroyed) ? 2 : 1);
        if(health <= 0)
        {
            GameObject.Find("Starchips").GetComponent<StarChipsManager>().AddStarChips(gameObject.GetComponent<IMonsterCard>().MonsterInfo.level);
            Destroy(gameObject);
            return;
        }
        healthBarBehaviour.SetHealth(health);
    }
}
