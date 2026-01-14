using UnityEngine;

public class MonsterReborn : MonoBehaviour
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
        if (transform.parent.name == "Hand")
            SendMessage("SetActivationPossible", GraveyardManager.instance.GetMonsterInGrave().Count > 0);
    }

    private void ActivateCard()
    {
        GraveyardManager.instance.ReviveMonsterFromGrave(card => true);
    }
}
