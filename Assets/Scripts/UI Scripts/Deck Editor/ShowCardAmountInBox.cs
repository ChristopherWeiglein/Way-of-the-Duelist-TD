using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowCardAmountInBox : MonoBehaviour
{
    private void OnEnable()
    {
        BoxHandler.OnAmountChanged += ShowAmount;
    }

    private void OnDisable()
    {
        BoxHandler.OnAmountChanged -= ShowAmount;
    }

    private void ShowAmount()
    {
        transform.Find("Image").gameObject.SetActive(true);
        transform.GetComponentInChildren<TMP_Text>().text = GameObject.Find("Box").GetComponent<BoxHandler>().GetCardAmountInBox(gameObject.GetComponent<InfoRoot>().cardData).ToString();
    }
}
