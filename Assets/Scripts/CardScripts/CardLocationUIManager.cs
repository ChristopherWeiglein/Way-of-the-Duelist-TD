using TMPro;
using UnityEngine;

public class CardLocationUIManager : MonoBehaviour
{
    public LocationDataTypes.CardLocationData cardLocationData;
    [SerializeField] private TMP_Text textElement;

    private void Start()
    {
        textElement.text = cardLocationData.cardLocation.ToString();
    }
}
