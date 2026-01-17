using JetBrains.Annotations;
using System;
using UnityEngine;

[Serializable]
public class TowerBuff
{
    public GameObject sender;
    public BuffStat stat;
    public float buffValue;
    
    public enum BuffStat
    {
        Attack,
        Speed,
        Range
    }

    public TowerBuff(GameObject sender, BuffStat stat, float buffValue)
    {
        this.sender = sender;
        this.stat = stat;
        this.buffValue = buffValue;
    }
}
