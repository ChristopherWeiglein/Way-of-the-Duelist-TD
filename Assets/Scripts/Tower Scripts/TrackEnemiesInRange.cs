using UnityEngine;
using System.Collections.Generic;

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

    public List<GameObject> GetEnemiesInRange() => enemiesInRange;
}
