using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ExtraDeckManager : MonoBehaviour
{
    public static ExtraDeckManager instance;
    public List<ExtraDeckMonsterData> extraDeck = new();  
    public List<FusionMonsterData> availableFusionSummons;
    [SerializeField] private TMP_Text extraDeckSize;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            SaveLoadHandler.LoadAllDeckLists();
            extraDeck = ConvertCardData.ToExtraDeckMonsterList(SaveLoadHandler.deckBoxes[0].extraDecklist);
        }
    }

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged()
    {
        SendMessage("CheckAvailableSummons");
        extraDeckSize.text = extraDeck.Count.ToString();
    }

    private void OnMouseDown()
    {
        if (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            return;

        OptionsManager.instance.ShowOptions(CardLocationPairFactory.AddLocationsToList(extraDeck.OfType<CardData>().ToList(), LocationDataTypes.CardLocation.ExtraDeck));
    }
}
