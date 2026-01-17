using UnityEngine;

public class Wasteland : MonoBehaviour
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
            if (!(towerInfo.MonsterInfo.type == CardDataTypes.MonsterType.Dinosaur || towerInfo.MonsterInfo.type == CardDataTypes.MonsterType.Zombie || towerInfo.MonsterInfo.type == CardDataTypes.MonsterType.Rock))
                continue;
            towerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Attack, 200));
            towerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Speed, 0.2f));
        }
    }
}
