using UnityEngine;

public interface IHandCard
{
    public bool NormalSummonPossible { get; set; }
    public bool activationPossible { get; set; }
    public bool specialSummonPossible {  get; set; }

    public void SetNormalSummonPossible(bool summonPossible)
    {
        NormalSummonPossible = summonPossible;
    }

    public void SetActivationPossible(bool activationPossible)
    {
        this.activationPossible = activationPossible;
    }
}
