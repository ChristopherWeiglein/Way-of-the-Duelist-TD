using UnityEngine;

public class BlockerHealthManager : MonoBehaviour
{
    [SerializeField] private int health;

    private void Start()
    {
        health = GetComponent<IMonsterCard>().MonsterInfo.defense;
    }

    public void ChangeHealth(int change)
    {
        health += Mathf.Abs(change) > 0 ? change : -1;
        if (health <= 0)
        {
            GetComponent<CardSendToGrave>().SendToGrave(new System.Collections.Generic.List<CardDataTypes.CardTags> { CardDataTypes.CardTags.DestroyedByBattle });
        }
    }
}
