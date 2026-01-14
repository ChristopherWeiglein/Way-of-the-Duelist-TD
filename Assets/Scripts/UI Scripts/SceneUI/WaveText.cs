using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{
    public TMP_Text textComponent;

    private void Start()
    {
        ShowText();
    }

    private void OnEnable()
    {
        GameManager.OnTurnStart += ShowText;
    }

    private void OnDisable()
    {
        GameManager.OnTurnStart -= ShowText;
    }

    public void ShowText()
    {
        textComponent.text = "Wave " + (SpawnManager.instance.WaveNumber + 1);
    } 
}
