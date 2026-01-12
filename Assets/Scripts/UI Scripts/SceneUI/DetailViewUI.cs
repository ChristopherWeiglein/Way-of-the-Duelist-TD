using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailViewUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;

    public void SetDetailView(CardData cardData)
    {
        image.sprite = cardData.GetCardInfo().sprite;
        text.text = cardData.GetCardInfo().cardText;
    }
}
