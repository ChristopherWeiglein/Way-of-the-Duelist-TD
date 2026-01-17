using UnityEngine;
using System;

public class TowerFactory : MonoBehaviour
{
    public static TowerFactory instance;
    [SerializeField] private GameObject summonedMonsters;
    [SerializeField] private GameObject buffers;

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
        newTower.GetComponent<InfoRoot>().cardData = card;
        newTower.GetComponent<InfoRoot>().cardInfo = card.GetCardInfo();
        newTower.GetComponent<IMonsterCard>().MonsterInfo = card.GetMonsterInfo();
        newTower.GetComponent<SpriteRenderer>().sprite = card.GetCardInfo().sprite;
        if (card.HasCardSpecificScript())
            newTower.AddComponent(Type.GetType(card.name));
    }


    public void CreateBufferSpell(BufferSpellData card)
    {
        GameObject newTower = Instantiate(card.GetTowerPrefab(), buffers.transform.position, Quaternion.identity, buffers.transform);
        newTower.GetComponent<InfoRoot>().cardData = card;
        newTower.GetComponent<InfoRoot>().cardInfo = card.GetCardInfo();
        newTower.GetComponent<SpriteRenderer>().sprite = card.GetCardInfo().sprite;
        if (card.HasCardSpecificScript())
            newTower.AddComponent(Type.GetType(card.name));
    }
}
