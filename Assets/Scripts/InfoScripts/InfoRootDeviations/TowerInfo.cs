using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static TowerDataTypes;

public class TowerInfo : InfoRoot, IMonsterCard
{
    public CardDataTypes.MonsterInfo MonsterInfo { get; set; }
    public static float baseRange = 50f;
    public static float baseCooldown = 2.0f;
    public TowerTarget towerTarget;
    public List<TowerBuff> buffs;
    public int power = 0;
    public float cooldown;
    public float range;
    public ProjectileData.OnTargetHit onTargetHit;


    private void Start()
    {
        StartCoroutine(WaitForMonsterInfo());
    }

    private IEnumerator WaitForMonsterInfo()
    {
        while(MonsterInfo.level == 0)
            yield return null;
        SetBaseRange();
        SetRange();
    }

    private void SetBaseRange()
    {
        range = baseRange / 2 + baseRange * MonsterInfo.level / 8;
    }

    private void SetRange()
    {
        transform.Find("Range").localScale = new Vector3(range, range, range);
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
    }

    public int GetAttackPower() => power;

    public float GetCooldown() => cooldown;

    private void OnEnable()
    {
        GameManager.OnWaveStart += CalculateValues;
    }

    private void OnDisable()
    {
        GameManager.OnWaveStart -= CalculateValues;
    }

    public void CalculateValues()
    {
        power = ConvertCardData.ToMonsterData(cardData).GetMonsterInfo().attack;
        cooldown = baseCooldown;
        SetBaseRange();
        foreach(TowerBuff buff in buffs)
        {
            switch (buff.stat)
            {
                case TowerBuff.BuffStat.Attack:
                    power += (int)buff.buffValue;
                    break;
                case TowerBuff.BuffStat.Speed:
                    cooldown *= (1-buff.buffValue);
                    break;
                case TowerBuff.BuffStat.Range:
                    range *= (1 + buff.buffValue);
                    break;
                default: 
                    break;
            }
        }
        SetRange();
    }

    public void AddEffectToProjectile(ProjectileData.OnTargetHit onTargetHit)
    {
        this.onTargetHit -= onTargetHit;
        this.onTargetHit += onTargetHit;
    }
}
