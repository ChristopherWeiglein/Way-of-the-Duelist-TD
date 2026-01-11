using UnityEngine;

public class TributeManager : MonoBehaviour
{
    public static TributeManager instance;
    public int remainingTributeCost = 0;

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

    public void SetTributeCost(MonsterData monsterData)
    {
        remainingTributeCost = monsterData.GetMonsterInfo().tributeCost;
        GameManager.EnterTributeMode();
    }

    public bool TryTribute(MonsterData monsterData)
    {
        if (remainingTributeCost <= 0)
            return false;

        remainingTributeCost--;
        if (remainingTributeCost <= 0)
            GameManager.LeaveTributeMode();
        return true;
    }
}
