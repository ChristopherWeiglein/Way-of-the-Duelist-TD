using System.Collections.Generic;
using UnityEngine;

public class BlockerInfo : InfoRoot, IMonsterCard
{
    public CardDataTypes.MonsterInfo MonsterInfo { get; set; }
    public List<TowerBuff> buffs;
    public int defense, attack;
    [SerializeField] private BlockerHealthManager healthManager;

    public void SetHealth()
    {
        CalculateValues();
        healthManager.SetMaxHealth(defense);
    }

    public void ReceiveBuff(TowerBuff buff)
    {
        TowerBuff towerBuff = buffs.Find(activeBuff => activeBuff.sender == buff.sender && activeBuff.stat == buff.stat);
        if (towerBuff == null)
        {
            buffs.Add(buff);
        }
        else
        {
            towerBuff.buffValue = buff.buffValue;
        }
        SetHealth();
    }

    private void OnEnable()
    {
        GameManager.OnWaveStart += SetHealth;
    }

    private void OnDisable()
    {
        GameManager.OnWaveStart -= SetHealth;
    }

    public void CalculateValues()
    {
        defense = MonsterInfo.defense;
        attack = MonsterInfo.attack;
        foreach (TowerBuff buff in buffs)
        {
            switch (buff.stat)
            {
                case TowerBuff.BuffStat.Attack:
                    attack += (int)buff.buffValue;
                    break;
                case TowerBuff.BuffStat.Defense:
                    defense = (int)(defense * (1 + buff.buffValue));
                    break;
                default:
                    break;
            }
        }
    }
}
