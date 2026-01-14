using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GraveyardManager : MonoBehaviour
{
    public static GraveyardManager instance;
    [SerializeField] TMP_Text text;

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

    private void OnEnable()
    {
        GameManager.OnCardSentToGrave += ShowGraveyardSize;
    }

    private void OnDisable()
    {
        GameManager.OnCardSentToGrave -= ShowGraveyardSize;
    }

    private void ShowGraveyardSize()
    {
        text.text = transform.childCount.ToString();
    }

    private void OnMouseDown()
    {
        if (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            return;

        List<LocationDataTypes.CardLocationData> graveyardList = GetGraveyardCardList();
        OptionsManager.instance.ShowOptions(graveyardList);
    }

    public List<LocationDataTypes.CardLocationData> GetGraveyardCardList()
    {
        List<LocationDataTypes.CardLocationData> graveyardList = new();
        foreach (Transform child in transform)
        {
            InfoRoot infoRoot = child.GetComponent<IGraveyardCard>() as InfoRoot;
            graveyardList.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = infoRoot.cardData, cardLocation = LocationDataTypes.CardLocation.Graveyard});
        }
        return graveyardList;
    }

    public List<LocationDataTypes.CardLocationData> GetGraveyardCardList(List<CardDataTypes.CardTags> cardTags)
    {
        List<LocationDataTypes.CardLocationData> graveyardList = new();
        foreach (Transform child in transform)
        {
            if (cardTags.Except(child.GetComponent<IGraveyardCard>().cardTags).Any())
                continue;
            InfoRoot infoRoot = child.GetComponent<IGraveyardCard>() as InfoRoot;
            graveyardList.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = infoRoot.cardData, cardLocation = LocationDataTypes.CardLocation.Graveyard });
        }
        return graveyardList;
    }

    public List<LocationDataTypes.CardLocationData> GetMonsterInGrave()
    {
        List<LocationDataTypes.CardLocationData> graveyardList = new();
        foreach (Transform child in transform)
        {
            InfoRoot infoRoot = child.GetComponent<IGraveyardCard>() as InfoRoot;
            if(infoRoot.cardData.GetCardInfo().cardType == CardDataTypes.CardType.Monster)
                graveyardList.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = infoRoot.cardData, cardLocation = LocationDataTypes.CardLocation.Graveyard });
        }
        return graveyardList;
    }

    public List<LocationDataTypes.CardLocationData> GetMonsterInGrave(List<CardDataTypes.CardTags> cardTags)
    {
        List<LocationDataTypes.CardLocationData> graveyardList = new();
        foreach (Transform child in transform)
        {
            if (cardTags.Except(child.GetComponent<IGraveyardCard>().cardTags).Any())
                continue;
            InfoRoot infoRoot = child.GetComponent<IGraveyardCard>() as InfoRoot;
            if (infoRoot.cardData.GetCardInfo().cardType == CardDataTypes.CardType.Monster)
                graveyardList.Add(new LocationDataTypes.CardLocationData { correlatingGameObject = child.gameObject, cardData = infoRoot.cardData, cardLocation = LocationDataTypes.CardLocation.Graveyard });
        }
        return graveyardList;
    }

    public void ReviveMonsterFromGrave(Predicate<MonsterData> condition)
    {
        StartCoroutine(RevivalSequence(condition));
    }

    private IEnumerator RevivalSequence(Predicate<MonsterData> condition)      
    {
        while (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            yield return null;
        List<LocationDataTypes.CardLocationData> graveyardCardlist = GetMonsterInGrave();
        List<MonsterData> cardOptions = CardLocationPairFactory.RemoveLocationsFromMonsterList(graveyardCardlist).FindAll(condition);
        OptionsManager.instance.ShowOptions(graveyardCardlist.FindAll(card => cardOptions.Contains(card.cardData as MonsterData)));
        while (OptionsManager.instance.SelectedCard.cardData == null)
            yield return null;
        Destroy(OptionsManager.instance.SelectedCard.correlatingGameObject);
        SummonManager.instance.SummonMonster(OptionsManager.instance.SelectedCard.cardData as MonsterData);
        ShowGraveyardSize();
    }

    public void AddCardFromGraveToHand(Predicate<CardData> condition)
    {
        StartCoroutine(AddBackSequence(condition));
    }

    private IEnumerator AddBackSequence(Predicate<CardData> condition)
    {
        while (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            yield return null;
        List<LocationDataTypes.CardLocationData> graveyardCardlist = GetGraveyardCardList();
        List<CardData> cardOptions = CardLocationPairFactory.RemoveLocationsFromCardList(graveyardCardlist).FindAll(condition);
        OptionsManager.instance.ShowOptions(graveyardCardlist.FindAll(card => cardOptions.Contains(card.cardData)));
        while(OptionsManager.instance.SelectedCard.cardData == null)
            yield return null;
        Destroy(OptionsManager.instance.SelectedCard.correlatingGameObject);
        CardFactory.instance.CreateCard(OptionsManager.instance.SelectedCard.cardData, transform.position, GameObject.Find("Hand"));
        ShowGraveyardSize();
    }

    public void AddMonsterFromGraveToHand(Predicate<MonsterData> condition)
    {
        StartCoroutine (AddBackSequence(condition));
    }

    public void AddMonsterFromGraveToHand(Predicate<MonsterData> condition, List<CardDataTypes.CardTags> cardTags)
    {
        StartCoroutine(AddBackSequence(condition, cardTags));
    }

    private IEnumerator AddBackSequence(Predicate<MonsterData> condition)
    {
        while (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            yield return null;
        List<LocationDataTypes.CardLocationData> graveyardCardlist = GetMonsterInGrave();
        List<MonsterData> cardOptions = CardLocationPairFactory.RemoveLocationsFromMonsterList(graveyardCardlist).FindAll(condition);
        OptionsManager.instance.ShowOptions(graveyardCardlist.FindAll(card => cardOptions.Contains(card.cardData as MonsterData)));
        while (OptionsManager.instance.SelectedCard.cardData == null)
            yield return null;
        Destroy(OptionsManager.instance.SelectedCard.correlatingGameObject);
        CardFactory.instance.CreateCard(OptionsManager.instance.SelectedCard.cardData, transform.position, GameObject.Find("Hand"));
        ShowGraveyardSize();
    }

    private IEnumerator AddBackSequence(Predicate<MonsterData> condition, List<CardDataTypes.CardTags> cardTags)
    {
        while (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            yield return null;
        List<LocationDataTypes.CardLocationData> graveyardCardlist = GetMonsterInGrave(cardTags);
        List<MonsterData> cardOptions = CardLocationPairFactory.RemoveLocationsFromMonsterList(graveyardCardlist).FindAll(condition);
        OptionsManager.instance.ShowOptions(graveyardCardlist.FindAll(card => cardOptions.FindAll(option => option.GetCardInfo().cardName == card.cardData.GetCardInfo().cardName).Count > 0));
        while (OptionsManager.instance.SelectedCard.cardData == null)
            yield return null;
        Destroy(OptionsManager.instance.SelectedCard.correlatingGameObject);
        CardFactory.instance.CreateCard(OptionsManager.instance.SelectedCard.cardData, transform.position, GameObject.Find("Hand"));
        ShowGraveyardSize();
    }
}
