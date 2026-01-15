using UnityEngine;

public class BlockerCheckCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;

        collision.GetComponent<MoveForward>().SetBack();
        GetComponent<BlockerHealthManager>().ChangeHealth(-collision.GetComponent<IMonsterCard>().MonsterInfo.attack);
        collision.GetComponent<EnemyHealthManager>().ChangeHealth(-gameObject.GetComponent<IMonsterCard>().MonsterInfo.attack);       
    }
}
