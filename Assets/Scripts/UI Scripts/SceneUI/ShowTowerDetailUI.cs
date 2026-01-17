using System.Collections.Generic;
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
    [SerializeField] private GameObject buffPrefab;
    [SerializeField] private GameObject buffsObject;
    private GameObject towerShown;

    private void Start()
    {
        foreach (TowerTarget towerTarget in TowerTarget.GetValues(typeof(TowerTarget)))
            target.options.Add(new TMP_Dropdown.OptionData(towerTarget.ToString()));
    }

    public void ShowTowerDetail(float speed, int power, TowerTarget towerTarget, GameObject towerShown, Sprite sprite, List<TowerBuff> buffList)
    {
        towerDetailPanel.SetActive(true);
        speedValue.text = (Mathf.Round(speed * 1000) / 1000).ToString();
        powerValue.text = power.ToString();
        this.towerShown = null;
        target.value = (int)towerTarget;
        this.towerShown = towerShown;
        imageComponent.sprite = sprite;

        foreach(Transform child in buffsObject.transform)
        {
            Destroy(child.gameObject);
        }

        for(int i = 0; i < buffList.Count; i++)
        {
            GameObject newBuff = Instantiate(buffPrefab, buffsObject.transform.position, Quaternion.identity, buffsObject.transform);
            newBuff.GetComponent<RectTransform>().anchoredPosition = new Vector3(140 * (int)(i/22), -20 * (i%22), 0);
            newBuff.GetComponentInChildren<Image>().sprite = buffList[i].sender.GetComponent<InfoRoot>().cardData.GetCardInfo().sprite;
            string text = "";
            switch (buffList[i].stat)
            {
                case TowerBuff.BuffStat.Attack:
                    text += "Attack";
                    break;
                case TowerBuff.BuffStat.Speed:
                    text += "Speed";
                    break;
                case TowerBuff.BuffStat.Range:
                    text += "Range";
                    break;
                case TowerBuff.BuffStat.Defense:
                    text += "Defense";
                    break;
                default:
                    text += "no buffed stat found";
                    break;
            }
            text += " " + buffList[i].buffValue.ToString();
            newBuff.GetComponentInChildren<TMP_Text>().text = text;
        }
    }

    public void OnDropDownChanged(int index)
    {
        if (towerShown == null)
            return;

        towerShown.GetComponent<TowerInfo>().towerTarget = (TowerTarget)index;
    }
}
