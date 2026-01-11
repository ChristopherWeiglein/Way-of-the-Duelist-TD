using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void EventAction();
    public static event EventAction OnWaveStart;
    public static event EventAction OnTurnStart;
    public static event EventAction OnCardDrawn;
    public static event EventAction OnGameStateChanged;
    public static event EventAction OnMonsterSummoned;
    public static event EventAction OnTowerPlacementEnter;
    public static event EventAction OnCardSentToGrave;
    public static event EventAction OnOpenGameState;
    public static event EventAction OnExtraDeckChecked;
    public static event EventAction OnCardAdded;

    public static GameMode CurrentGameMode { get; private set; } = GameMode.Idle;

    public enum GameMode
    {
        Idle,
        WaveMode,
        TowerPlacement,
        TributeMode,
        FusionSummonMode,
        SelectionMode
    }

    public static void TryEnterWaveMode()
    {
        if(CurrentGameMode != GameMode.Idle)
            return;

        CurrentGameMode = GameMode.WaveMode;
        OnWaveStart?.Invoke();
    }

    public static void TryEndWave()
    {
        if (CurrentGameMode != GameMode.WaveMode)
            return;

        CurrentGameMode = GameMode.Idle;
        OnTurnStart?.Invoke();       
        OnOpenGameState?.Invoke();
    }

    public static void CardDrawn()
    {
        OnCardDrawn?.Invoke();
        OnGameStateChanged?.Invoke();
    }

    public static void EnterTowerPlacementMode()
    {
        CurrentGameMode = GameMode.TowerPlacement;
        OnTowerPlacementEnter?.Invoke();
    }

    public static void TowerPlaced()
    {
        if(CurrentGameMode != GameMode.TowerPlacement)
            return;

        CurrentGameMode = GameMode.Idle;
        OnGameStateChanged?.Invoke();
        OnOpenGameState?.Invoke();
    }

    public static void NormalSummonsIncreased()
    {
        OnGameStateChanged?.Invoke();
    }

    public static void EnterTributeMode()
    {
        CurrentGameMode = GameMode.TributeMode;
    }

    public static void LeaveTributeMode()
    {
        CurrentGameMode = GameMode.Idle;
    }

    public static void CardSentToGrave()
    {
        OnCardSentToGrave?.Invoke();
    }

    public static void EnterFusionMode()
    {
        CurrentGameMode = GameMode.FusionSummonMode;
    }

    public static void LeaveFusionMode()
    {
        CurrentGameMode = GameMode.Idle;
    }

    public static void EnterSelectionMode()
    {
        CurrentGameMode = GameMode.SelectionMode;
    }

    public static void LeaveSelectionMode()
    {
        CurrentGameMode = GameMode.Idle;
    }

    public static void OnCardAddedToHand()
    {
        OnCardAdded?.Invoke();   
        OnGameStateChanged?.Invoke();
    }

}
