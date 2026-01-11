using UnityEngine;
using UnityEngine.UI;

public class CardHMI : MonoBehaviour
{
    [SerializeField] private GameObject buttonNormalSummon;
    [SerializeField] private GameObject buttonActivate;
    [SerializeField] private GameObject buttonSpecialSummon;
    private IHandCard cardInfoManager;

    private bool buttonsActive = false;

    private void Start()
    {
        cardInfoManager = GetComponent<IHandCard>();
    }

    private void OnMouseDown()
    {
        if (GameManager.CurrentGameMode != GameManager.GameMode.Idle)
            return;

        if (buttonsActive)
        {
            DeactivateButtons();
        }
        else
        {
            gameObject.transform.parent.BroadcastMessage("DeactivateButtons");
            buttonNormalSummon.SetActive(cardInfoManager.NormalSummonPossible);
            buttonActivate.SetActive(cardInfoManager.activationPossible);
            buttonSpecialSummon.SetActive(cardInfoManager.specialSummonPossible);
            buttonsActive = true;           
        }
    }

    private void DeactivateButtons()
    {
        buttonNormalSummon.SetActive(false);
        buttonActivate.SetActive(false);
        buttonSpecialSummon.SetActive(false);
        buttonsActive = false;
    }
}
