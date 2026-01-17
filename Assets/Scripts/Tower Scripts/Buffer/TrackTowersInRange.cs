using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackTowersInRange : MonoBehaviour
{
    [SerializeField] private ContactFilter2D contactFilter;
    [SerializeField] private int range;
    [SerializeField] private List<GameObject> towersInRange = new();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Towers"))
            return;

        towersInRange.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.CompareTag("Towers"))
            return;

        towersInRange.Remove(collision.gameObject);
    }

    public List<GameObject> GetTowersInRange() => towersInRange;
}
