using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExtraDeckBoxHandler : MonoBehaviour
{
    private List<CardData> extraDeckList;

    public void InstantiateExtraDeck(List<CardData> extradecklist)
    {
        if(transform.childCount > 0)
            BroadcastMessage("Destroy");
        extraDeckList = extradecklist;
        ShowDeckList();
    }

    private void ShowDeckList()
    {
        extraDeckList = extraDeckList.OrderBy(card => card.GetCardInfo().cardName).ToList();
        foreach (CardData card in extraDeckList)
        {
            DeckEditorCardFactory.instance.CreateDeckEditorCard(card, transform);
        }
    }
}
