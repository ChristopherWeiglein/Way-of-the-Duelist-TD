using UnityEngine;

public class Polymerization : MonoBehaviour
{
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
        if(transform.parent.name == "Hand")
            SendMessage("SetActivationPossible", ExtraDeckManager.instance.availableFusionSummons.Count > 0);
    }

    private void ActivateCard()
    {
        FusionManager.instance.StartFusionSummon();
    }
}
