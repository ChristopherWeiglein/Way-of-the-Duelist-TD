using UnityEngine;
using UnityEngine.UI;

public class HighlightCard : MonoBehaviour
{
    [SerializeField] private Image highlight;

    public void HighlightThisCard()
    {
        transform.parent.BroadcastMessage("DehighlightThisCard");
        highlight.enabled = true;
    }

    public void DehighlightThisCard()
    {
        highlight.enabled = false;
    }
}
