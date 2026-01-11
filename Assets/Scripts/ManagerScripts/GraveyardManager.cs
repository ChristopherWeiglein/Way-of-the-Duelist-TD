using System.Collections.Generic; 
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

        List<CardData> graveyardList = new();
        foreach(Transform child in transform)
        {
            graveyardList.Add(child.GetComponent<GraveyardCardInfo>().cardData);
        }
        OptionsManager.instance.ShowOptions(graveyardList);
    }
}
