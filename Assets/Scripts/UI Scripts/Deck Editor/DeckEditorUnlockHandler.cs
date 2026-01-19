using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DeckEditorUnlockHandler : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList;
    [SerializeField] private List<GameObject> unlockObjects;
    private MultiDeckHandler multiDeckHandler;
    [SerializeField] private int starchips;
    [SerializeField] private int unlockedDeckslots;

    private void OnEnable()
    {
        multiDeckHandler = GetComponent<MultiDeckHandler>();
        SaveLoadHandler.LoadProfileData();
        starchips = SaveLoadHandler.starchips;
        unlockedDeckslots = SaveLoadHandler.unlockedDeckSlots;
        for(int i = 0; i < unlockObjects.Count; i++)
        {
            unlockObjects[i].SetActive(i >= unlockedDeckslots);
            buttonList[i].interactable = i < unlockedDeckslots;
        }
    }

    public bool TryUnlockSlot(int deckslot, int starchipRequirement, int cardRequirement)
    {
        if(deckslot != unlockedDeckslots + 1)
        {
            GameObject.Find("Message").GetComponent<MessageHandler>().ShowMessageForSeconds("unlock previous deckslots first", 3);
            return false;
        }
        if(starchipRequirement > starchips)
        {
            GameObject.Find("Message").GetComponent<MessageHandler>().ShowMessageForSeconds("not enough starchips", 3);
            return false;
        }
        int totalCards = GetTotalCards();
        if (cardRequirement > totalCards)
        {
            GameObject.Find("Message").GetComponent<MessageHandler>().ShowMessageForSeconds("not enough cards\n" + totalCards + "/" + cardRequirement, 3);
            return false;
        }

        unlockedDeckslots++;
        buttonList[unlockedDeckslots - 1].interactable = true;
        multiDeckHandler.NewDeckSlotAdded();
        return true;
    }

    private int GetTotalCards()
    {
        SaveLoadHandler.LoadCardList();
        List<DeckEditorDataTypes> cards = SaveLoadHandler.cardList;
        int totalCards = 0;
        foreach(DeckEditorDataTypes card in cards)
        {
            totalCards += card.amount >= 3 ? 3 : card.amount;
        }
        return totalCards;
    }

    public void SaveProfile()
    {
        SaveLoadHandler.SaveProfileData(starchips, SaveLoadHandler.records, unlockedDeckslots);
    }
}
