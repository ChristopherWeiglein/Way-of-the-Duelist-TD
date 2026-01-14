using UnityEngine;

public class test : MonoBehaviour
{
    public void Tutor()
    {
        DeckManager.instance.AddCardFromDeckToHand(card => true);
    }
}
