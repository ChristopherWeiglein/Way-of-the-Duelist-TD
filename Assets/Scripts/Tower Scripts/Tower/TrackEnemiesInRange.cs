using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TrackEnemiesInRange : MonoBehaviour
{
    private List<GameObject> enemiesInRange = new List<GameObject>();

    private void OnEnable()
    {
        GameManager.OnTurnStart += ClearList;
    }

    private void OnDisable()
    {
        GameManager.OnTurnStart -= ClearList;
    }

    private void ClearList()
    {
        enemiesInRange.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }

    public List<GameObject> GetEnemiesInRange()
    {
        switch (transform.parent.GetComponent<TowerInfo>().towerTarget)
        {
            case TowerDataTypes.TowerTarget.First:
                return enemiesInRange.OrderByDescending(enemy => enemy.GetComponent<MoveForward>().GetDistance()).ToList();
            case TowerDataTypes.TowerTarget.Last:
                return enemiesInRange.OrderBy(enemy => enemy.GetComponent<MoveForward>().GetDistance()).ToList();
            case TowerDataTypes.TowerTarget.MostHealth:
                return enemiesInRange.OrderByDescending(enemy => enemy.GetComponent<EnemyHealthManager>().health).ToList();
            case TowerDataTypes.TowerTarget.LeastHealth:
                return enemiesInRange.OrderBy(enemy => enemy.GetComponent<EnemyHealthManager>().health).ToList();
            default:
                return enemiesInRange;
        }
    }
}
