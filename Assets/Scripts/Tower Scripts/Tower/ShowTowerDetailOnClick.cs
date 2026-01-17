using UnityEngine;

public class ShowTowerDetailOnClick : MonoBehaviour
{
    [SerializeField] private TowerInfo towerInfo;

    private void OnMouseDown()
    {
        towerInfo.CalculateValues();
        GameObject.Find("DataPanel").GetComponent<ShowTowerDetailUI>().ShowTowerDetail(towerInfo.GetCooldown(), towerInfo.GetAttackPower(), towerInfo.towerTarget, gameObject, towerInfo.cardData.GetCardInfo().sprite, towerInfo.buffs);
    }
}
