using System.Collections;
using UnityEngine;

public class BlockerHealthManager : MonoBehaviour
{
    public int health { get; private set; }
    public int lostHealth { get; private set; } = 0;
    public int maxHealth { get; private set; } = 0;
    [SerializeField] private HealthBarBehaviour healthBarBehaviour;

    private void Start()
    {
        StartCoroutine(WaitForMonsterInfo());
    }

    private IEnumerator WaitForMonsterInfo()
    {
        BlockerInfo blockerInfo = GetComponent<BlockerInfo>();
        while(blockerInfo.MonsterInfo.level == 0)   
            yield return null;
        maxHealth = GetComponent<BlockerInfo>().MonsterInfo.defense;
        healthBarBehaviour.SetMaxHealth(maxHealth);
    }

    public void ChangeHealth(int change)
    {
        health += Mathf.Abs(change) > 0 ? change : -1;
        lostHealth -= Mathf.Abs(change) > 0 ? change : -1;
        if (health <= 0)
        {
            GetComponent<CardSendToGrave>().SendToGrave(new System.Collections.Generic.List<CardDataTypes.CardTags> { CardDataTypes.CardTags.DestroyedByBattle });
            return;
        }
        healthBarBehaviour.SetHealth(health);
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        healthBarBehaviour.SetMaxHealth(maxHealth);       
        health = maxHealth - lostHealth;
        healthBarBehaviour.SetHealth(health);
    }
}
