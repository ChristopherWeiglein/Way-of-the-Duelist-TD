using UnityEngine;

public class Umiiruka : MonoBehaviour
{
    private TrackTowersInRange towerTracker;
    private BufferSpellData bufferData;

    private void Start()
    {
        bufferData = GetComponent<InfoRoot>().cardData as BufferSpellData;

        if (gameObject.CompareTag("HandCard"))
            SendMessage("SetActivationPossible", true);

        if (gameObject.CompareTag("Buffer"))
            towerTracker = GetComponentInChildren<TrackTowersInRange>();
    }

    private void ActivateCard()
    {
        GameManager.EnterTowerPlacementMode();
        TowerFactory.instance.CreateBufferSpell(bufferData);
    }

    private void OnEnable()
    {
        if (gameObject.CompareTag("Buffer"))
            GameManager.OnOpenGameState += ApplyBuffs;
    }

    private void OnDisable()
    {
        if (gameObject.CompareTag("Buffer"))
            GameManager.OnOpenGameState -= ApplyBuffs;
    }

    private void ApplyBuffs()
    {
        foreach (GameObject tower in towerTracker.GetTowersInRange())
        {
            TowerInfo towerInfo = tower.GetComponent<TowerInfo>();
            if (towerInfo.MonsterInfo.attribute != CardDataTypes.MonsterAttribute.Water)
                continue;
            towerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Attack, 500));
            towerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Range, 0.2f));
        }
    }
}
