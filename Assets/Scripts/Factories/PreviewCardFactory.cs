using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreviewCardFactory : MonoBehaviour
{
    [SerializeField] private GameObject previewCardPrefab;

    public void CreateCard(WaveScript.EnemyAmountPair enemyAmountPair)
    {
        GameObject newCard = Instantiate(previewCardPrefab, transform.position, Quaternion.identity, transform);
        newCard.GetComponent<InfoRoot>().cardData = enemyAmountPair.enemy;
        newCard.GetComponent<InfoRoot>().cardInfo = enemyAmountPair.enemy.GetCardInfo();
        newCard.GetComponentInChildren<TMP_Text>().text = enemyAmountPair.amount.ToString();
        newCard.GetComponent<IMonsterCard>().MonsterInfo = enemyAmountPair.enemy.GetMonsterInfo();
        newCard.GetComponent<Image>().sprite = enemyAmountPair.enemy.GetCardInfo().sprite;
        newCard.GetComponent<PreviewInfo>().CalculateStats();
        newCard.GetComponent<ShowEnemyDetailsOnClick>().ShowDetails();
    }
}
