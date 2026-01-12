using Unity.VisualScripting;
using UnityEngine;

public class StartWaveButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        GameManager.TryEnterWaveMode();
    }
}
