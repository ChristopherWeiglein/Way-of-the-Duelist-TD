using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Linq;

public static class SaveLoadHandler
{
    public static List<DeckEditorDataTypes> cardList;
    public static List<CardData> deckList;
    public static List<CardData> extraDeckList;
    public static int starchips;
    public static int[] records;
    private static readonly string decklistPath = Application.persistentDataPath + "Decklist.ygotd";
    private static readonly string cardlistPath = Application.persistentDataPath + "Cardlist.ygotd";
    private static readonly string profilePath = Application.persistentDataPath + "Profile.ygotd";

    //Called from DeckEditor
    public static void SaveDeckList()
    {
        List<CardData> deckList = GameObject.Find("Deck").GetComponent<DeckBoxHandler>().GetDeckList();
        List<CardData> extraDeckList = GameObject.Find("ExtraDeck").GetComponent<ExtraDeckBoxHandler>().GetExtraDeckList();

        SaveFileDeckList saveFileObject = new(deckList, extraDeckList);

        BinaryFormatter formatter = new();

        FileStream fileStream = new(decklistPath, FileMode.Create);

        formatter.Serialize(fileStream, saveFileObject);
        fileStream.Close();
    }

    public static void SaveProfileData(int starchips, int[] records)
    {
        SaveFileProfile saveFileObject = new(starchips, records);

        BinaryFormatter formatter = new();

        FileStream fileStream = new(profilePath, FileMode.Create);

        formatter.Serialize(fileStream, saveFileObject);
        fileStream.Close();
    }

    public static void LoadDeckList()
    {
        if(File.Exists(decklistPath))
        {
            BinaryFormatter formatter = new();
            FileStream fileStream = new(decklistPath, FileMode.Open);

            SaveFileDeckList data = formatter.Deserialize(fileStream) as SaveFileDeckList;
            fileStream.Close();

            List<CardData> allCards = Resources.LoadAll<CardData>("CardData").ToList();

            deckList = new();
            foreach(string cardName in data.deckList)
            {
                deckList.Add(allCards.Find(card => card.name == cardName));
            }

            extraDeckList = new();
            foreach(string cardName in data.extraDeckList)
            {
                extraDeckList.Add(allCards.Find(cardList => cardList.name == cardName));
            }
        }
        else
        {
            PredefinedSave saveData = Resources.Load<PredefinedSave>("SaveData/StartingSave");
            deckList = new();
            foreach(CardData card in saveData.GetDeckList())
            {
                deckList.Add(card);
            }
            extraDeckList = new();
            foreach(CardData card in saveData.GetExtraDeckList())
            {
                extraDeckList.Add(card);
            }
        }
    }

    public static void LoadProfileData()
    {
        if (File.Exists(profilePath))
        {
            BinaryFormatter formatter = new();
            FileStream fileStream = new(profilePath, FileMode.Open);

            SaveFileProfile data = formatter.Deserialize(fileStream) as SaveFileProfile;
            fileStream.Close();

            starchips = data.starchips;
            records = data.records;
        }
        else
        {
            PredefinedSave saveData = Resources.Load<PredefinedSave>("SaveData/StartingSave");

            starchips = saveData.GetStarChips();
            records = saveData.GetRecords();
        }
    }

    public static void LoadCardList()
    {
        if (File.Exists(cardlistPath))
        {
            BinaryFormatter formatter = new();
            FileStream fileStream = new(cardlistPath, FileMode.Open);

            SaveFileCardList data = formatter.Deserialize(fileStream) as SaveFileCardList;
            fileStream.Close();

            List<CardData> allCards = Resources.LoadAll<CardData>("CardData").ToList();
            cardList = new();
            for (int i = 0; i < data.cardList.Length; i++)
            {
                cardList.Add(new DeckEditorDataTypes(allCards.Find(card => card.name == data.cardList[i]), data.cardListAmount[i]));
            }
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
