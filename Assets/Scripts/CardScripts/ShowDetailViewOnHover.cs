using UnityEngine;

public class ShowDetailViewOnHover : MonoBehaviour
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
}
