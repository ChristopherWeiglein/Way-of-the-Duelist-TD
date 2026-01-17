using UnityEngine;

public class ChorusOfSanctuary : MonoBehaviour
{
    private TrackTowersInRange towerTracker;
    private BufferSpellData bufferData;

    private void Start()
    {
        bufferData = GetComponent<InfoRoot>().cardData as BufferSpellData;

        if (gameObject.CompareTag("HandCard"))
            SendMessage("SetActivationPossible", true);

        if (gameObject.CompareTag("Buffer"))
        {
            towerTracker = GetComponentInChildren<TrackTowersInRange>();
            towerTracker.TagToTrack = "Blocker";
        }
            
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
            BlockerInfo blockerInfo = tower.GetComponent<BlockerInfo>();
            if (!(blockerInfo.MonsterInfo.type == CardDataTypes.MonsterType.Insect || blockerInfo.MonsterInfo.type == CardDataTypes.MonsterType.Beast || blockerInfo.MonsterInfo.type == CardDataTypes.MonsterType.Plant || blockerInfo.MonsterInfo.type == CardDataTypes.MonsterType.BeastWarrior))
                continue;
            blockerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Attack, 500));
            blockerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Defense, 0.2f));
        }
    }
}
