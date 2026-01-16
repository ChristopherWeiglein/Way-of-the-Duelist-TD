using UnityEngine;

public class ShowEnemyDetailsOnClick : MonoBehaviour
{
    [SerializeField] private PreviewInfo previewInfo;

    public void ShowDetails()
    {
        GameObject.Find("PreviewDetail").GetComponent<PreviewDetail>().ShowValues(previewInfo.health, previewInfo.speed, previewInfo.MonsterInfo.attack, previewInfo.cardInfo.cardName);
        GetComponent<HighlightCard>().HighlightThisCard();
    }
}
