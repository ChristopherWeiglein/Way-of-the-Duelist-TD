using TMPro;
using UnityEngine;

public class CardLocationUIManager : MonoBehaviour
{
    public LocationDataTypes.CardLocation cardLocation;
    [SerializeField] private TMP_Text textElement;

    private void Start()
    {
        textElement.text = cardLocation.ToString();
    }
}
