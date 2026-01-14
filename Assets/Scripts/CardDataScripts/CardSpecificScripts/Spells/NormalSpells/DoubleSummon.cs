using UnityEngine;

public class DoubleSummon : MonoBehaviour
{
    private void Start()
    {
        if (transform.parent.name == "Hand")
            SendMessage("SetActivationPossible", true);
    }

    private void ActivateCard()
    {
        GameObject.Find("FieldPrefab").GetComponent<NormalSummonManager>().IncreaseNormalSummon();
    }
}
