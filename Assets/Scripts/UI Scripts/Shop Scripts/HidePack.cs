using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HidePack : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text packname;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text cost;

    public void Hide()
    {
        image.enabled = false;
        packname.enabled = false;
        button.enabled = false;
        cost.enabled = false;
    }

    public void Show()
    {
        image.enabled = true;
        packname.enabled = true;
        button.enabled = true;
        cost.enabled = true;
    }
}
