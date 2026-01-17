using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowBlockerDetailUI : MonoBehaviour
{
    [SerializeField] private GameObject blockerPanel;
    [SerializeField] private Image cardImage;
    [SerializeField] private TMP_Text healthValue;
    [SerializeField] private TMP_Text maxHealthValue;
    [SerializeField] private TMP_Text powerValue;

    public void ShowBlockerDetail(Sprite cardSprite, int health, int maxHealth, int power)
    {
        blockerPanel.SetActive(true);
        cardImage.sprite = cardSprite;
        healthValue.text = health.ToString();
        maxHealthValue.text = maxHealth.ToString();
        powerValue.text = power.ToString();
    }
}
