using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void OnSliderChanged()
    {
        Time.timeScale = slider.value;
    }
}
