using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOpeningManager : MonoBehaviour
{
    [SerializeField] private GameObject pullsPanel;
    public void OpenPack(List<CardData> pulls)
    {
        AddPullsToCardList(pulls);
        StartCoroutine(OpeningSequence(pulls));
    }

    private IEnumerator OpeningSequence(List<CardData> pulls)
    {
        BroadcastMessage("Hide");
        pullsPanel.SetActive(true);
        foreach(CardData card in pulls)
        {
            yield return new WaitForSecondsRealtime(2);
            DeckEditorCardFactory.instance.CreateDeckEditorCard(card, pullsPanel.transform);        
        }
        yield return new WaitForSecondsRealtime(2);
        pullsPanel.BroadcastMessage("Destroy");
        pullsPanel.SetActive(false);
        BroadcastMessage("Show");
    }

    private void AddPullsToCardList(List<CardData> pulls)
    {
        SaveLoadHandler.LoadCardList();
        List<DeckEditorDataTypes> cardList = SaveLoadHandler.cardList;
        foreach (CardData card in pulls)
            cardList = AddCardToCardList(cardList, card);
        SaveLoadHandler.SaveCardList(cardList);
    }

    private List<DeckEditorDataTypes> AddCardToCardList(List<DeckEditorDataTypes> cardList, CardData cardData)
    {
        if(cardList.Find(card => card.cardData.name == cardData.name) != null)
        {
            cardList.Find(card => card.cardData.name == cardData.name).amount++;
        }
        else
        {
            cardList.Add(new DeckEditorDataTypes(cardData, 1));
        }
        return cardList;
    } 
}
