using UnityEngine;

public class ShowDetailViewOnHover : MonoBehaviour
{
    [SerializeField] private InfoRoot info;
    private void OnMouseEnter()
    {
        GameObject.Find("CardDetailPanel").GetComponent<DetailViewUI>().SetDetailView(info.cardData);
    }
}
