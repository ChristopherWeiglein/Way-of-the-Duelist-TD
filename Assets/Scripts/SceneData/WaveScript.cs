using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "WaveScript", menuName = "Scriptable Objects/WaveScript")]
public class WaveScript : ScriptableObject
{
    [Serializable]
    public struct EnemyAmountPair
    {
        public MonsterData enemy;
        public int amount;
    }

    [Serializable]
    public struct WaveList
    {
        public List<EnemyAmountPair> waveList;
    }

    public List<WaveList> waveEnemyList = new();
}
