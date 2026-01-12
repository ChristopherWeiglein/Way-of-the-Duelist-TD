using UnityEngine;

public class EndOfRoad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealthManager.instance.ChangePlayerHealth(collision.gameObject.GetComponent<EnemyInfo>().MonsterInfo.attack * -1);
            Destroy(collision.gameObject);
        }
    }
}
