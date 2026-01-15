using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckForAvailableFusionSummons : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject summonedMonsters;

    private void CheckAvailableSummons()
    {
        List<MonsterData> monsterInRotation;
        bool fusionPossible = false;
        bool fusionMaterialAvailable = false;

        ExtraDeckManager.instance.availableFusionSummons.Clear();
        foreach (FusionMonsterData extraDeckMonster in ExtraDeckManager.instance.extraDeck)
        {
            if (extraDeckMonster.GetMonsterInfo().monsterTags.Contains(CardDataTypes.MonsterTags.Fusion))
            {
                monsterInRotation = GetMonsterInRotation();

                fusionPossible = true;
                foreach (MonsterData fusionMaterial in extraDeckMonster.GetFusionMaterial())
                {
                    fusionMaterialAvailable = false;
                    foreach (MonsterData cardData in monsterInRotation)
                    {
                        if (FusionManager.instance.CompareFusionMaterial(cardData, fusionMaterial))
                        {
                            fusionMaterialAvailable = true;
                            monsterInRotation.Remove(cardData);
                            break;
                        }
                    }
                    fusionPossible &= fusionMaterialAvailable;
                }
                if (fusionPossible)
                    ExtraDeckManager.instance.availableFusionSummons.Add(extraDeckMonster);
            }
        }
    }

    private List<MonsterData> GetMonsterInRotation()
    {
        List<MonsterData> monsterInRotation = new();
        CardData cardData = null;
        foreach(Transform cardTransform in hand.transform)
        {
            cardData = cardTransform.gameObject.GetComponent<InfoRoot>().cardData;
            if (cardData.GetCardInfo().cardType != CardDataTypes.CardType.Monster)
                continue;
            monsterInRotation.Add((MonsterData)cardData);
        }
        foreach(Transform cardTransform in summonedMonsters.transform)
        {
            monsterInRotation.Add((MonsterData)cardTransform.gameObject.GetComponent<InfoRoot>().cardData);
        }
        return monsterInRotation;
    }
}
