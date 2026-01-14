using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FusionRecovery : MonoBehaviour
{
    private List<CardDataTypes.CardTags> cardTags = new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.UsedAsFusionMaterial };

    private void OnEnable()
    {
        GameManager.OnOpenGameState += CheckIfActivationIsPossible;
    }

    private void OnDisable()
    {
        GameManager.OnOpenGameState -= CheckIfActivationIsPossible;
    }

    private void CheckIfActivationIsPossible()
    {
        bool fusionmaterialInGrave = GraveyardManager.instance.GetMonsterInGrave().FindAll(card => card.correlatingGameObject.GetComponent<IGraveyardCard>().cardTags.Contains(CardDataTypes.CardTags.UsedAsFusionMaterial)).Count > 0;
        bool polymerizationInGrave = GraveyardManager.instance.GetGraveyardCardList().FindAll(card => card.cardData.GetCardInfo().cardName == "Polymerization").Count > 0;
        if (transform.parent.name == "Hand")
            SendMessage("SetActivationPossible", fusionmaterialInGrave && polymerizationInGrave);
    }

    private void ActivateCard()
    {
        GraveyardManager.instance.AddCardFromGraveToHand(card => card.GetCardInfo().cardName == "Polymerization");
        GraveyardManager.instance.AddMonsterFromGraveToHand(card => !card.GetMonsterInfo().monsterTags.Any(x => CardDataTypes.extraDeckTags.Any(y => y == x)), cardTags);
    }
}
