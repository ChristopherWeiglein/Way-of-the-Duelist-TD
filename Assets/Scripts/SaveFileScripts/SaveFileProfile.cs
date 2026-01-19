using MemoryPack;
using NUnit.Framework;
using UnityEngine;

[MemoryPackable]
[System.Serializable]
public partial class SaveFileProfile
{
    public int starchips;
    public int[] records;
    public int unlockedDeckslots;

    public SaveFileProfile(int starchips, int[] records, int unlockedDeckslots)
    {
        this.starchips = starchips;
        this.records = records;
        this.unlockedDeckslots = unlockedDeckslots;
    }
}
