using System.Collections.Generic;
using UnityEngine;

public class TheAForces : MonoBehaviour
{
    private TrackTowersInRange towerTracker;
    private BufferSpellData bufferData;
    private int buffAmount;

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

    private void CalculateBuffs()
    {
        int numberOfWarriorAndSpellcasters = 0;
        foreach (GameObject tower in towerTracker.GetTowersInRange())
        {
            CardDataTypes.MonsterInfo monsterInfo = tower.GetComponent<TowerInfo>().MonsterInfo;
            if (monsterInfo.type == CardDataTypes.MonsterType.Warrior || monsterInfo.type == CardDataTypes.MonsterType.Spellcaster)
                numberOfWarriorAndSpellcasters++;
        }
        buffAmount = numberOfWarriorAndSpellcasters * 200;
    }

    private void ApplyBuffs()
    {
        CalculateBuffs();
        foreach (GameObject tower in towerTracker.GetTowersInRange())
        {
            TowerInfo towerInfo = tower.GetComponent<TowerInfo>();
            if (!(towerInfo.MonsterInfo.type == CardDataTypes.MonsterType.Warrior))
                continue;
            towerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Attack, buffAmount));
        }
    }
}
