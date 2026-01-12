using UnityEngine;

public class CardSelection : MonoBehaviour
{
    private InfoRoot cardInfoManager;

    private void Start()
    {
        cardInfoManager = GetComponent<InfoRoot>();
    }

    private void OnMouseDown()
    {
        OptionsManager.instance.SelectCard(GetComponent<CardLocationUIManager>().cardLocationData);
        transform.parent.BroadcastMessage("DestroyCard");
    }

    private void DestroyCard()
    {
        Destroy(gameObject);
    }
}
