using UnityEngine;

public class NormalSummonCard : MonoBehaviour
{
    [SerializeField] private InfoRoot cardInfoManager;

    private void Start()
    {
        cardInfoManager = GetComponent<IMonsterCard>() as InfoRoot;
    }

    private void NormalSummonThisCard()
    {
        GameObject.Find("FieldPrefab").GetComponent<NormalSummonManager>().NormalSummonMonster((MonsterData)cardInfoManager.cardData);
        Destroy(gameObject);
    }
}
