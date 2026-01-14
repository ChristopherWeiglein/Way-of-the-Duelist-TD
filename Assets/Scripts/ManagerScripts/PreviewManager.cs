using System.Collections.Generic;
using UnityEngine;

public class PreviewManager : MonoBehaviour
{
    [SerializeField] private PreviewCardFactory factory;

    public void ShowNextWave(List<WaveScript.EnemyAmountPair> wavelist)
    {
        if(factory.gameObject.transform.childCount != 0)
            BroadcastMessage("Destroy");
        foreach(WaveScript.EnemyAmountPair card in wavelist)
        {
            factory.CreateCard(card);
        }
    }
}
