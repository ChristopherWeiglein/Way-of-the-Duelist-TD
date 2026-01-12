using System.Collections.Generic;
using UnityEngine;

public class SummonedMonstersManager : MonoBehaviour
{
    public static SummonedMonstersManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public List<LocationDataTypes.CardLocationData> GetSummonedMonsterList()
    {
        List<LocationDataTypes.CardLocationData> list = new();

        foreach(Transform child in transform)
        {
            list.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = child.GetComponent<InfoRoot>().cardData, cardLocation = LocationDataTypes.CardLocation.Field });
        }

        return list;
    }
}
