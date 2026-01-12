using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory instance;
    [SerializeField] private GameObject enemyPrefab;

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

    public void CreateEnemy(MonsterData monsterData, GameObject spawnPoint)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, spawnPoint.transform);
        newEnemy.GetComponent<EnemyInfo>().cardData = monsterData;
        newEnemy.GetComponent<EnemyInfo>().MonsterInfo = monsterData.GetMonsterInfo();
        newEnemy.GetComponent<SpriteRenderer>().sprite = monsterData.GetCardInfo().sprite;
    }
}
