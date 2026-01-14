using UnityEngine;

public class PotOfGreed : MonoBehaviour
{
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
        if(transform.parent.name == "Hand")
            SendMessage("SetActivationPossible", DeckManager.instance.GetDeckCount() >= 2);
    }

    private void ActivateCard()
    {
        DeckManager.instance.DrawCardsFromDeck(2);
    }
}
