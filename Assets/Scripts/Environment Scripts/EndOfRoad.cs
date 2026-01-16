using UnityEngine;

public class EndOfRoad : MonoBehaviour
{
    private const int damageForZeroAttackEnemies = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int enemyattack = collision.gameObject.GetComponent<EnemyInfo>().MonsterInfo.attack;
            PlayerHealthManager.instance.ChangePlayerHealth(-enemyattack);
            Destroy(collision.gameObject);
        }
    }
}
