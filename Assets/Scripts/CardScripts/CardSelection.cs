using UnityEngine;

public class CardSelection : MonoBehaviour
{
    [SerializeField] private CardInfoManager cardInfoManager;

    private void OnMouseDown()
    {
        OptionsManager.instance.SelectCard(cardInfoManager.cardData);
        transform.parent.BroadcastMessage("DestroyCard");
    }

    private void DestroyCard()
    {
        Destroy(gameObject);
    }
}
