using UnityEngine;

public class ShowBlockerDetailsOnClick : MonoBehaviour
{
    [SerializeField] private BlockerInfo blockerInfo;
    [SerializeField] private BlockerHealthManager healthManager;

    private void OnMouseDown()
    {
        blockerInfo.SetHealth();
        GameObject.Find("DataPanel").GetComponent<ShowBlockerDetailUI>().ShowBlockerDetail(blockerInfo.cardData.GetCardInfo().sprite, healthManager.health, healthManager.maxHealth, blockerInfo.attack);
    }
}
