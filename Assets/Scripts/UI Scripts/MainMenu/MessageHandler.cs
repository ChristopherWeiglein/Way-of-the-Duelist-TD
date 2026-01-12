using System.Collections;
using TMPro;
using UnityEngine;

public class MessageHandler : MonoBehaviour
{
    [SerializeField] private GameObject messageObject;
    [SerializeField] private TMP_Text textComponent;
    public void ShowMessageForSeconds(string message, float seconds)
    {
        StartCoroutine(MessageSequence(message,seconds));
    }

    private IEnumerator MessageSequence(string message, float seconds)
    {
        textComponent.text = message;
        messageObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        messageObject.SetActive(false);
    }
}
