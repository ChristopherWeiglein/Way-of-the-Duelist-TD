using System.Collections.Generic;
using UnityEngine;

public class AwakeningOfThePossessed : MonoBehaviour
{
    private TrackTowersInRange towerTracker;
    private BufferSpellData bufferData;
    private int buffAmount;
    private bool canStillActivateThisTurn = true;

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
        {
            GameManager.OnOpenGameState += ApplyBuffs;
            GameManager.OnMonsterSummoned += CheckIfSummonedInRange;
            GameManager.OnTurnStart += OncePerTurnReset;
        }           
    }

    private void OnDisable()
    {
        if (gameObject.CompareTag("Buffer"))
        {
            GameManager.OnOpenGameState -= ApplyBuffs;
            GameManager.OnMonsterSummoned -= CheckIfSummonedInRange; 
            GameManager.OnTurnStart -= OncePerTurnReset;
        }
            
    }

    private void OncePerTurnReset()
    {
        canStillActivateThisTurn = true;
    }

    private void CheckIfSummonedInRange(GameObject sender)
    {
        if (!towerTracker.GetTowersInRange().Contains(sender) || !sender.CompareTag("Towers") || !canStillActivateThisTurn)
            return;

        CardDataTypes.MonsterInfo monsterInfo = ConvertCardData.ToMonsterData(sender.GetComponent<TowerInfo>().cardData).GetMonsterInfo();
        if (monsterInfo.type != CardDataTypes.MonsterType.Spellcaster || monsterInfo.attack != 1850)
            return;

        DeckManager.instance.DrawCardsFromDeck(1);
        canStillActivateThisTurn = false;
    }

    private void CalculateBuffs()
    {
        List<CardDataTypes.MonsterAttribute> list = new();
        foreach(GameObject tower in towerTracker.GetTowersInRange())
        {
            TowerInfo towerInfo = tower.GetComponent<TowerInfo>();
            if(!list.Contains(towerInfo.MonsterInfo.attribute))
                list.Add(towerInfo.MonsterInfo.attribute);
        }
        buffAmount = list.Count * 300;
    }

    private void ApplyBuffs()
    {
        CalculateBuffs();
        foreach (GameObject tower in towerTracker.GetTowersInRange())
        {           
            TowerInfo towerInfo = tower.GetComponent<TowerInfo>();
            towerInfo.ReceiveBuff(new TowerBuff(gameObject, TowerBuff.BuffStat.Attack, buffAmount));
        }
    }
}
