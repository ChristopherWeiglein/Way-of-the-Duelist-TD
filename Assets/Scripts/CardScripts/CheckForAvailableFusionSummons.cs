using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckForAvailableFusionSummons : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject summonedMonsters;

    public List<FusionMonsterData> CheckAvailableSummons(List<LocationDataTypes.CardLocation> fusionMaterialLocations)
    {
        List<MonsterData> monsterInRotation;
        List<FusionMonsterData> availableFusions = new();
        bool fusionPossible;
        bool fusionMaterialAvailable;

        List<FusionMonsterData> possibleFusions = new();
        foreach (FusionMonsterData extraDeckMonster in ExtraDeckManager.instance.extraDeck)
        {
            if (extraDeckMonster.GetMonsterInfo().monsterTags.Contains(CardDataTypes.MonsterTags.Fusion))
            {
                monsterInRotation = GetCardsInRotation.GetMonsterInRotation(fusionMaterialLocations);

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
                    availableFusions.Add(extraDeckMonster);//ExtraDeckManager.instance.availableFusionSummons.Add(extraDeckMonster);
            }
        }
        return availableFusions;
    }
}
