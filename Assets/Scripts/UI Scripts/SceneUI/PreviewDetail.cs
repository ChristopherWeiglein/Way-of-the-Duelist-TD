using UnityEngine;
using TMPro;

public class PreviewDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text healthValue;
    [SerializeField] private TMP_Text speedValue;
    [SerializeField] private TMP_Text damageValue;
    [SerializeField] private TMP_Text cardName;

    public void ShowValues(int health, float speed, int damage, string name)
    {
        healthValue.text = health.ToString();
        speedValue.text = (Mathf.Round(speed * 100) / 100).ToString();
        cardName.text = name.ToString();
        damageValue.text = damage.ToString();
    }
}
