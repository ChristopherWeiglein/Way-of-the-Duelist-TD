using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PackData", menuName = "Scriptable Objects/PackData")]
public class PackData : ScriptableObject
{
    [SerializeField] private List<CardData> commonPulls;
    [SerializeField] private List<CardData> rarePulls;
    [SerializeField] private int commonCardsPerPack;
    [SerializeField] private int rareCardsPerPack;
    [SerializeField] private int prizePerPack;

    public List<CardData> GetCommonPulls()
    {
        List<CardData> list = new();
        foreach (CardData card in commonPulls)
            list.Add(card);
        return list;
    }

    public List<CardData> GetRarePulls()
    {
        List<CardData> list = new();
        foreach(CardData card in rarePulls)
            list.Add(card);
        return list;
    }

    public int GetCommonCardsPerPack() => commonCardsPerPack;
    public int GetRareCardsPerPack() => rareCardsPerPack;
    public int GetPrizePerPack() => prizePerPack;
}
