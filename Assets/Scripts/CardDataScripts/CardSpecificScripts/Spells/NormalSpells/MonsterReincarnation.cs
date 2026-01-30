using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterReincarnation : MonoBehaviour
{
    private DiscardCardFromHand discardCardFromHand;
    private void Start()
    {
        discardCardFromHand = GameObject.Find("Hand").GetComponent<DiscardCardFromHand>();
        if (transform.parent.name == "Hand")
            GetComponent<OnSpellActivation>().enabled = false;
    }
    private void OnEnable()
    {
        GameManager.OnGameStateChanged += CheckIfActivationIsPossible;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= CheckIfActivationIsPossible;
    }

    private void CheckIfActivationIsPossible()
    {
        if (transform.parent.name == "Hand")
            SendMessage("SetActivationPossible", GraveyardManager.instance.GetMonsterInGrave().Count > 0);
    }

    private void ActivateCard()
    {
        StartCoroutine(ActivationSequence());
    }

    private IEnumerator ActivationSequence()
    {
        Debug.Log("Discard");
        discardCardFromHand.DiscardCardForCost(1, card => card.correlatingGameObject != gameObject);
        while (!discardCardFromHand.costPayed)
            yield return null;
        Debug.Log("Start AddBack");
        GraveyardManager.instance.AddMonsterFromGraveToHand(monster => true);
        GraveyardCardFactory.instance.CreateGraveyardCard(GetComponent<InfoRoot>().cardData, new List<CardDataTypes.CardTags>() { CardDataTypes.CardTags.ActivatedSpellCard });
        Destroy(gameObject);
    }
}
