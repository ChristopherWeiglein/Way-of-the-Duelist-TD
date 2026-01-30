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
        if(projectileData.target == collision.gameObject)
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().ChangeHealth(-projectileData.power);
            projectileData.onTargetHit?.Invoke(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
