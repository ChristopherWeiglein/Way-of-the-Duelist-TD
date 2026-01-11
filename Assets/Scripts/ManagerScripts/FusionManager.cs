using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FusionManager : MonoBehaviour
{
    public static FusionManager instance;
    public List<MonsterData> remainingFusionmaterial = new();

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

    public void StartFusionSummon()
    {
        StartCoroutine(FusionSummonSequence());      
    }

    public bool TryUseAsFusionMaterial(MonsterData monsterData)
    {
        foreach(MonsterData cardData in remainingFusionmaterial)
        {
            if (CompareFusionMaterial(monsterData, cardData))
            {
                remainingFusionmaterial.Remove(cardData);
                    
                return true;
            }
        }
        return false;
    }

    public bool CompareFusionMaterial(MonsterData monsterToCompare, MonsterData requiredFusionMaterial)
    {
        if (monsterToCompare.GetCardInfo().cardName != requiredFusionMaterial.GetCardInfo().cardName && requiredFusionMaterial.GetCardInfo().cardName != string.Empty)
            return false;

        if (monsterToCompare.GetMonsterInfo().attribute != requiredFusionMaterial.GetMonsterInfo().attribute && requiredFusionMaterial.GetMonsterInfo().attribute != CardDataTypes.MonsterAttribute.None)
            return false;

        if (monsterToCompare.GetMonsterInfo().type != requiredFusionMaterial.GetMonsterInfo().type && requiredFusionMaterial.GetMonsterInfo().type != CardDataTypes.MonsterType.None)
            return false;

        foreach(CardDataTypes.MonsterTags monsterTag in requiredFusionMaterial.GetMonsterInfo().monsterTags)
        {
            if (!monsterToCompare.GetMonsterInfo().monsterTags.Contains(monsterTag))
                return false;
        }

        return true;
    }

    private IEnumerator FusionSummonSequence()
    {
        TextMessageManager.instance.ShowMessage("Choose a card to summon");
        OptionsManager.instance.ShowOptions(ExtraDeckManager.instance.availableFusionSummons.OfType<CardData>().ToList());
        while(GameManager.CurrentGameMode == GameManager.GameMode.SelectionMode)
            yield return null;
        TextMessageManager.instance.ShowMessage("Choose the cards used as fusion material");
        GameManager.EnterFusionMode();
        remainingFusionmaterial.Clear();        
        FusionMonsterData fusionMonsterData = (FusionMonsterData)OptionsManager.instance.selectedCard;
        ExtraDeckManager.instance.extraDeck.Remove(ExtraDeckManager.instance.extraDeck.Find(card => card.GetCardInfo().cardName == fusionMonsterData.GetCardInfo().cardName));
        remainingFusionmaterial.AddRange(fusionMonsterData.GetFusionMaterial());
        while (remainingFusionmaterial.Count > 0)
            yield return null;
        GameManager.LeaveFusionMode();
        SummonManager.instance.SummonMonster(fusionMonsterData);  

    }
}
