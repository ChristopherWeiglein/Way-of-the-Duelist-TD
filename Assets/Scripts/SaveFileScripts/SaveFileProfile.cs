using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class SaveFileProfile
{
    public int starchips;
    public int[] records;

    public SaveFileProfile(int starchips, int[] records)
    {
        this.starchips = starchips;
        this.records = records;
    }
}
