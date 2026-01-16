using UnityEngine;

public class ShowTowerDetailOnClick : MonoBehaviour
{
    [SerializeField] private TowerInfo towerInfo;

    private void OnMouseDown()
    {
        if (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            return;

        GameObject.Find("DataPanel").GetComponent<ShowTowerDetailUI>().ShowTowerDetail(GetComponent<ShootProjectile>().GetSpeed(), towerInfo.MonsterInfo.attack, towerInfo.towerTarget, gameObject, towerInfo.cardData.GetCardInfo().sprite);
    }
}
