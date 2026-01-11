using UnityEngine;

public class ProjectileHitTarget : MonoBehaviour
{
    private ProjectileData projectileData;

    private void Start()
    {
        projectileData = gameObject.GetComponent<ProjectileData>();         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(projectileData.target ==  collision.gameObject)
        {
            EnemyHealthManager targetHealthManager = collision.gameObject.GetComponent<EnemyHealthManager>();
            targetHealthManager.health -= projectileData.power;
            if(targetHealthManager.health <= 0)
            {
                Destroy(projectileData.target);
            }
            Destroy(gameObject);
        }
    }
}
