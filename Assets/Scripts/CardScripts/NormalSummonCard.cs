using UnityEngine;

public class NormalSummonCard : MonoBehaviour
{
    [SerializeField] private CardInfoManager cardInfoManager;

    private void NormalSummonThisCard()
    {
        NormalSummonManager.instance.NormalSummonMonster((MonsterData)cardInfoManager.cardData);
        Destroy(gameObject);
    }
}
