using UnityEngine;
using System;

public class TowerFactory : MonoBehaviour
{
    public static TowerFactory instance;
    [SerializeField] private GameObject summonedMonsters;

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

    public void CreateTower(MonsterData card)
    {
        GameObject newTower = Instantiate(card.GetTowerPrefab(), summonedMonsters.transform.position, Quaternion.identity, summonedMonsters.transform);
        newTower.GetComponent<TowerInfo>().cardData = card;
        newTower.GetComponent<SpriteRenderer>().sprite = card.GetCardInfo().sprite;
        if (card.HasCardSpecificScript())
            newTower.AddComponent(Type.GetType(card.name));
    }
}
