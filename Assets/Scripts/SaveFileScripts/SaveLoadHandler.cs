using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Linq;
using MemoryPack;

public static class SaveLoadHandler
{
    public static List<DeckEditorDataTypes> cardList;
    public static List<Deck> deckBoxes;
    public static int starchips;
    public static int[] records;
    public static int unlockedDeckSlots;
    private static readonly string decklistPath = Application.persistentDataPath + "\\Decklists.ygotd";
    private static readonly string cardlistPath = Application.persistentDataPath + "\\Cardlist.ygotd";
    private static readonly string profilePath = Application.persistentDataPath + "\\Profile.ygotd";

    public static async void SaveDeckList(List<Deck> deckboxes)
    {
        SaveFileDeckList saveFileObject = new(deckBoxes);

        FileStream fileStream = new(decklistPath, FileMode.Create);

        await MemoryPackSerializer.SerializeAsync(fileStream, saveFileObject);
        fileStream.Close();
    }

    public static async void SaveProfileData(int starchips, int[] records, int unlockedDeckslots)
    {
        SaveFileProfile saveFileObject = new(starchips, records, unlockedDeckslots);

        FileStream fileStream = new(profilePath, FileMode.Create);

        await MemoryPackSerializer.SerializeAsync(fileStream, saveFileObject);
        fileStream.Close();
    }

    public static async void SaveCardList(List<DeckEditorDataTypes> cardlist)
    {
        SaveFileCardList saveFileObject = new(cardlist);
        FileStream fileStream = new(cardlistPath, FileMode.Create);
        await MemoryPackSerializer.SerializeAsync(fileStream, saveFileObject);
        fileStream.Close();
    }

    public static void LoadAllDeckLists()
    {
        LoadProfileData();
        if (File.Exists(decklistPath))
        {
            FileStream fileStream = new(decklistPath, FileMode.Open);
            SaveFileDeckList decks = MemoryPackSerializer.DeserializeAsync<SaveFileDeckList>(fileStream).Result;
            List<CardData> allCards = Resources.LoadAll<CardData>("CardData").ToList();
            deckBoxes = new();
            foreach(DeckString deckString in decks.deckboxes)
            {
                Deck deck = new(new(), new());
                foreach(string cardName in deckString.decklist)
                    deck.decklist.Add(allCards.Find(a => a.name == cardName));
                foreach (string cardName in deckString.extradecklist)
                    deck.extraDecklist.Add(allCards.Find(a => a.name == cardName));
                deckBoxes.Add(deck);
            }

            fileStream.Close();
        }
        else
        {
            PredefinedSave saveData = Resources.Load<PredefinedSave>("SaveData/StartingSave");

            deckBoxes = saveData.GetDecks();
        }
    }

    public static void LoadProfileData()
    {
        if (File.Exists(profilePath))
        {

            FileStream fileStream = new(profilePath, FileMode.Open);

            SaveFileProfile data = MemoryPackSerializer.DeserializeAsync<SaveFileProfile>(fileStream).Result;
            fileStream.Close();

            starchips = data.starchips;
            records = data.records;
            unlockedDeckSlots = data.unlockedDeckslots;
        }
        else
        {
            PredefinedSave saveData = Resources.Load<PredefinedSave>("SaveData/StartingSave");

            starchips = saveData.GetStarChips();
            records = saveData.GetRecords();
            unlockedDeckSlots = saveData.GetUnlockedDeckslots();
        }
    }

    public static void LoadCardList()
    {
        if (File.Exists(cardlistPath))
        {
            FileStream fileStream = new(cardlistPath, FileMode.Open);

            SaveFileCardList data = MemoryPackSerializer.DeserializeAsync<SaveFileCardList>(fileStream).Result;

            List<CardData> allCards = Resources.LoadAll<CardData>("CardData").ToList();

            cardList = new();
            foreach (StringIntPair card in data.cardList)
            {
                cardList.Add(new DeckEditorDataTypes(allCards.Find(a => a.name == card.text), card.number));
            }
            fileStream.Close();

        }
        else
        {
            PredefinedSave saveData = Resources.Load<PredefinedSave>("SaveData/StartingSave");
            cardList = new();
            foreach(DeckEditorDataTypes card in saveData.GetCardList())
            {
                cardList.Add(new DeckEditorDataTypes(card.cardData, card.amount));
            }
        }
    }
}
