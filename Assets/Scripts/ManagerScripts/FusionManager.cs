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

    public void StartFusionSummon(List<LocationDataTypes.CardLocation> fusionMaterialLocations, List<FusionMonsterData> possibleFusions)
    {       
        StartCoroutine(FusionSummonSequence(fusionMaterialLocations, possibleFusions));      
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

    private List<LocationDataTypes.CardLocationData> GetMonsterInRotation(List<LocationDataTypes.CardLocation> fusionMaterialLocations)
    {
        List<LocationDataTypes.CardLocationData> list = new();

        if (fusionMaterialLocations.Contains(LocationDataTypes.CardLocation.Hand))
            list.AddRange(HandManager.instance.GetMonstersInHand());

        if (fusionMaterialLocations.Contains(LocationDataTypes.CardLocation.Field))
            list.AddRange(SummonedMonstersManager.instance.GetSummonedMonsterList());

        if (fusionMaterialLocations.Contains(LocationDataTypes.CardLocation.Graveyard))
            list.AddRange(GraveyardManager.instance.GetMonsterInGrave());

        //GetMonsterInDeck
        
        return list;
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

    private IEnumerator FusionSummonSequence(List<LocationDataTypes.CardLocation> fusionMaterialLocations, List<FusionMonsterData> possibleFusions)
    {
        TextMessageManager.instance.ShowMessage("Choose a card to summon");
        if(!OptionsManager.instance.ShowOptions(CardLocationPairFactory.AddLocationsToList(possibleFusions.OfType<CardData>().ToList(), LocationDataTypes.CardLocation.ExtraDeck)))
            yield break;
        while(GameManager.CurrentGameMode == GameManager.GameMode.SelectionMode)
            yield return null;
        TextMessageManager.instance.ShowMessage("Choose the cards used as fusion material");
        GameManager.EnterFusionMode();
        remainingFusionmaterial.Clear();        
        FusionMonsterData fusionMonsterData = (FusionMonsterData)OptionsManager.instance.SelectedCard.cardData;       
        remainingFusionmaterial.AddRange(fusionMonsterData.GetFusionMaterial());
        foreach(MonsterData fusionmaterial in remainingFusionmaterial)
        {
            if(!OptionsManager.instance.ShowOptions(GetMonsterInRotation(fusionMaterialLocations).FindAll(card => CompareFusionMaterial((MonsterData)card.cardData, fusionmaterial))))
                yield break;
            while (OptionsManager.instance.SelectedCard.cardData == null)
                yield return null;

            switch (OptionsManager.instance.SelectedCard.cardLocation)
            {
                case LocationDataTypes.CardLocation.Field:
                    OptionsManager.instance.SelectedCard.correlatingGameObject.SendMessage("SendToGrave", new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.UsedAsFusionMaterial, CardDataTypes.CardTags.SentFromField });
                    break;
                case LocationDataTypes.CardLocation.Deck:
                    DeckManager.instance.SendCardToGrave(OptionsManager.instance.SelectedCard.cardData, new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.UsedAsFusionMaterial, CardDataTypes.CardTags.SentFromDeck});
                    break;
                case LocationDataTypes.CardLocation.Hand:
                    OptionsManager.instance.SelectedCard.correlatingGameObject.SendMessage("SendToGrave", new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.UsedAsFusionMaterial, CardDataTypes.CardTags.SentFromHand });
                    break;
                case LocationDataTypes.CardLocation.ExtraDeck:
                case LocationDataTypes.CardLocation.Banishment:
                default:
                    break;
            }
            yield return null;
        }       
        ExtraDeckManager.instance.extraDeck.Remove(ExtraDeckManager.instance.extraDeck.Find(card => card.GetCardInfo().cardName == fusionMonsterData.GetCardInfo().cardName));
        GameManager.LeaveFusionMode();
        SummonManager.instance.SummonMonster(fusionMonsterData);  

    }
}
