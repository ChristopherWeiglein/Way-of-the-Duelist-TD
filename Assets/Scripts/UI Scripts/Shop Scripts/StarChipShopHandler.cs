using TMPro;
using UnityEngine;

public class StarChipShopHandler : MonoBehaviour
{
    private int starchips;
    [SerializeField] private TMP_Text textComponent;

    private void OnEnable()
    {
        SaveLoadHandler.LoadProfileData();
        starchips = SaveLoadHandler.starchips;
        ShowStarChipsAmount();
    }

    public bool TrySubtractStarchips(int amount)
    {
        if (amount > starchips)
            return false;

        starchips -= amount;
        SaveLoadHandler.SaveProfileData(starchips, SaveLoadHandler.records, SaveLoadHandler.unlockedDeckSlots);
        ShowStarChipsAmount();
        return true;
    }

    private void ShowStarChipsAmount()
    {
        textComponent.text = starchips.ToString();
    }
}
