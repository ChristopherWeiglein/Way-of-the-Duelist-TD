using UnityEngine;

public class PotOfGreed : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnCardDrawn += CheckIfActivationIsPossible;
    }

    private void OnDisable()
    {
        GameManager.OnCardDrawn -= CheckIfActivationIsPossible;
    }

    private void CheckIfActivationIsPossible()
    {
        if(transform.parent.name == "Hand")
            SendMessage("SetActivationPossible", DeckManager.instance.deck.Count >= 2);
    }

    private void ActivateCard()
    {
        DeckManager.instance.DrawCardsFromDeck(2);
    }
}
