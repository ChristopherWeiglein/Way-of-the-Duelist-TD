using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailViewUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text cardInfo;
    [SerializeField] private TMP_Text atk;
    [SerializeField] private TMP_Text def;
    [SerializeField] private TMP_Text towerType;

    public void SetDetailView(CardData cardData)
    {
        image.sprite = cardData.GetCardInfo().sprite;
        text.text = cardData.GetCardInfo().cardText;

        switch (cardData.GetCardInfo().cardType)
        {
            case CardDataTypes.CardType.Monster:
                CardDataTypes.MonsterInfo monsterInfo = ConvertCardData.ToMonsterData(cardData).GetMonsterInfo();
                cardInfo.text = monsterInfo.attribute.ToString() + "/" + monsterInfo.type.ToString();
                foreach (CardDataTypes.MonsterTags monsterTag in monsterInfo.monsterTags)
                    cardInfo.text += "/" + monsterTag.ToString();
                atk.text = "ATK : " + monsterInfo.attack.ToString();
                def.text = "DEF : " + monsterInfo.defense.ToString();
                towerType.text = "Towertype : " + ConvertCardData.ToMonsterData(cardData).GetTowerPrefab().name;
                break;
            case CardDataTypes.CardType.Spell:
                cardInfo.text = "Spell/" + ConvertCardData.ToSpellType(cardData).GetSpellType().ToString();
                atk.text = "";
                def.text = "";
                towerType.text = (cardData is BufferSpellData) ? "Towertype : " + ConvertCardData.ToBufferSpellData(cardData).GetTowerPrefab().name : "";
                break;
            case CardDataTypes.CardType.Trap:
                break;
            default: 
                break;
        }
    }
}
