using UnityEngine;
using TMPro;

public class PreviewDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text healthValue;
    [SerializeField] private TMP_Text speedValue;

    public void ShowValues(int health, float speed)
    {
        healthValue.text = health.ToString();
        speedValue.text = (Mathf.Round(speed * 100) / 100).ToString(); 
    }
}
