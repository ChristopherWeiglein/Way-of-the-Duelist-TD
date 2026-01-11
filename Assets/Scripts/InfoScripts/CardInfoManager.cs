using UnityEngine;

public class CardInfoManager : InfoRoot
{
    public bool normalSummonPossible = false;
    public bool activationPossible = false;
    public bool specialSummonPossible = false;

    public void SetSummonPossible(bool summonPossible)
    {
        this.normalSummonPossible = summonPossible;
    }

    public void SetActivationPossible(bool activationPossible)
    {
        this.activationPossible = activationPossible;
    }
}
