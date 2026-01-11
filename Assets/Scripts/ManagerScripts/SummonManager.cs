using UnityEngine;

public class SummonManager : MonoBehaviour
{
    public static SummonManager instance;

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

    public void SummonMonster(MonsterData monster)
    {
        GameManager.EnterTowerPlacementMode();
        TowerFactory.instance.CreateTower(monster);
    }
}
