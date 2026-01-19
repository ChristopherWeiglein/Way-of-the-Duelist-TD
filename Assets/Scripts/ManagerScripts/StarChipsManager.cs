using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarChipsManager : MonoBehaviour
{
    public int starchips { get; private set; }
    private int[] records;
    [SerializeField] private TMP_Text textComponent;

    private void Start()
    {
        SaveLoadHandler.LoadProfileData();
        starchips = SaveLoadHandler.starchips;
        records = SaveLoadHandler.records;
        ShowStarChips();
    }

    private void OnEnable()
    {
        GameManager.OnTurnStart += SaveCurrentData;
    }

    private void OnDisable()
    {
        GameManager.OnTurnStart -= SaveCurrentData;
    }

    private void SaveCurrentData()
    {
        int recordsIndex = SceneHelperFunctions.GetRecordsIndexFromSceneName(SceneManager.GetActiveScene().name);
        if(SpawnManager.instance.WaveNumber > records[recordsIndex])
        {
            records[recordsIndex] = SpawnManager.instance.WaveNumber;
        }
        SaveLoadHandler.SaveProfileData(starchips, records, SaveLoadHandler.unlockedDeckSlots);
    }

    public void AddStarChips(int starchips)
    {
        this.starchips += starchips;
        ShowStarChips();
    }

    public void ShowStarChips()
    {
        textComponent.text = starchips.ToString();
    }
}
