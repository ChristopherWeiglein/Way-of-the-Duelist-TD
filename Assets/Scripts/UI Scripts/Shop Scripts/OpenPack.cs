using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenPack : MonoBehaviour
{
    [SerializeField] private PackData packData;
    [SerializeField] private TMP_Text cost;

    private void OnEnable()
    {
        cost.text = packData.GetPrizePerPack().ToString();
    }

    public void Open()
    {
        if (!GameObject.Find("Shop").GetComponent<StarChipShopHandler>().TrySubtractStarchips(packData.GetPrizePerPack()))
            return;

        List<CardData> pulls = new();
        for(int i = 0; i < packData.GetCommonCardsPerPack(); i++)
        {
            pulls.Add(packData.GetCommonPulls()[Random.Range(0,packData.GetCommonPulls().Count)]);
        }
        for(int i = 0; i < packData.GetRareCardsPerPack(); i++)
        {
            pulls.Add(packData.GetRarePulls()[Random.Range(0,packData.GetRarePulls().Count)]);
        }
        transform.parent.gameObject.GetComponent<PackOpeningManager>().OpenPack(pulls);
    }
}
