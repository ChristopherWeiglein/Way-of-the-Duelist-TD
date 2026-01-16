using UnityEngine;
using UnityEngine.EventSystems;

public class ShowDetailViewOnHover : MonoBehaviour, IPointerEnterHandler
{
    private InfoRoot info;

    private void Start()
    {
        info = GetComponent<InfoRoot>();
    }

    private void OnMouseEnter()
    {
        GameObject.Find("CardDetailPanel").GetComponent<DetailViewUI>().SetDetailView(info.cardData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.Find("CardDetailPanel").GetComponent<DetailViewUI>().SetDetailView(info.cardData);
    }
}
