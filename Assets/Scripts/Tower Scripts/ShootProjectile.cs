using System.Collections;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    private float cooldown;
    private int power;
    private TrackEnemiesInRange trackEnemiesInRange;
    [SerializeField] private TowerInfo towerInfo;
    [SerializeField] private GameObject projectile;

    void Start()
    {
        MonsterData monsterData = (MonsterData)towerInfo.cardData;

        trackEnemiesInRange = GetComponentInChildren<TrackEnemiesInRange>();
        cooldown = 1 - monsterData.GetMonsterInfo().level / 20;
        power = monsterData.GetMonsterInfo().attack;
        StartCoroutine(ShootEnemy());
    }

    private IEnumerator ShootEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            while (ShootProjectileAtEnemy())
                yield return null;
        }
    }

    private bool ShootProjectileAtEnemy()
    {
        if(trackEnemiesInRange.GetEnemiesInRange().Count > 0 && !GetComponent<TowerPlacement>().enabled)
        {
            CreateProjectile();
            return false;
        }
        else
        {
            return true;
        }
    }

    private void CreateProjectile()
    {
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
        ProjectileData projectileData = newProjectile.GetComponent<ProjectileData>();
        projectileData.target = trackEnemiesInRange.GetEnemiesInRange()[0];
        projectileData.power = power;
    }
}
