using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TowerDataTypes;

public class ShowTowerDetailUI : MonoBehaviour
{
    [SerializeField] private GameObject towerDetailPanel;
    [SerializeField] private TMP_Text speedValue;
    [SerializeField] private TMP_Text powerValue;
    [SerializeField] private TMP_Dropdown target;
    [SerializeField] private Image imageComponent;
    private GameObject towerShown;

    private void Start()
    {
        foreach (TowerTarget towerTarget in TowerTarget.GetValues(typeof(TowerTarget)))
            target.options.Add(new TMP_Dropdown.OptionData(towerTarget.ToString()));
    }

    public void ShowTowerDetail(float speed, int power, TowerTarget towerTarget, GameObject towerShown, Sprite sprite)
    {
        towerDetailPanel.SetActive(true);
        speedValue.text = speed.ToString();
        powerValue.text = power.ToString();
        this.towerShown = null;
        target.value = (int)towerTarget;
        this.towerShown = towerShown;
        imageComponent.sprite = sprite;
    }

    public void OnDropDownChanged(int index)
    {
        if (towerShown == null)
            return;

        towerShown.GetComponent<TowerInfo>().towerTarget = (TowerTarget)index;
    }
}
