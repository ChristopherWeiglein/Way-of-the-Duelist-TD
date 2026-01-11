using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainManager : MonoBehaviour
{
    public static ChainManager instance;

    public delegate void ChainLink();
    public List<ChainLink> effectChain = new();

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
        GameManager.OnOpenGameState += OnOpenGameState;
    }

    private void OnDisable()
    {
        GameManager.OnOpenGameState -= OnOpenGameState;
    }

    private void OnOpenGameState()
    {
        StartCoroutine(ResolveChain());
    }

    private IEnumerator ResolveChain()
    {
        while (effectChain.Count > 0)
        {
            while (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
                yield return null;
            effectChain[effectChain.Count - 1]();
            effectChain.RemoveAt(effectChain.Count - 1);
        }
    }

    public void AddChainLink(ChainLink chainLink)
    {
        effectChain.Add(chainLink);
    }
}
