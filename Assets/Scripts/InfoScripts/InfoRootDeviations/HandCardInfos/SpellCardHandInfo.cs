using UnityEngine;

public class SpellCardHandInfo : InfoRoot, IHandCard
{
    public bool NormalSummonPossible { get; set; } = false;
    public bool activationPossible { get; set; } = false;
    public bool specialSummonPossible { get; set; } = false;

    public void SetNormalSummonPossible(bool summonPossible)
    {
        NormalSummonPossible = summonPossible;
    }

    public void SetActivationPossible(bool activationPossible)
    {
        this.activationPossible = activationPossible;
    }
}
