using System.Collections.Generic;
using UnityEngine;

public class Polymerization : MonoBehaviour
{
    private List<FusionMonsterData> availableFusionSummons;

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
        availableFusionSummons = GameObject.Find("ExtraDeck").GetComponent<CheckForAvailableFusionSummons>().CheckAvailableSummons(new List<LocationDataTypes.CardLocation> { LocationDataTypes.CardLocation.Hand, LocationDataTypes.CardLocation.Field});
        if(transform.parent.name == "Hand")
            SendMessage("SetActivationPossible", availableFusionSummons.Count > 0);
    }

    private void ActivateCard()
    {
        FusionManager.instance.StartFusionSummon(new System.Collections.Generic.List<LocationDataTypes.CardLocation> { LocationDataTypes.CardLocation.Hand, LocationDataTypes.CardLocation.Field}, availableFusionSummons);
    }
}
