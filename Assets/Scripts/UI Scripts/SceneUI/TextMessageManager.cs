using UnityEngine;
using TMPro;
using System.Collections;

public class TextMessageManager : MonoBehaviour
{
    public static TextMessageManager instance;

    [SerializeField] private GameObject panel;
    private TMP_Text text;

    [SerializeField] private GameObject textMessagePrefab;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        text = panel.GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        GameManager.OnWaveStart += WaveMessage;
        GameManager.OnTurnStart += WaveFinishedMessage;
        GameManager.OnOpenGameState += OnOpenGameState;
    }

    private void OnDisable()
    {
        GameManager.OnWaveStart -= WaveMessage;
        GameManager.OnTurnStart -= WaveFinishedMessage;
        GameManager.OnOpenGameState -= OnOpenGameState;
    }

    private void OnOpenGameState()
    {
        panel.SetActive(false);
    }

    private void WaveMessage()
    {
        ShowMessageForSeconds("Wave " + (SpawnManager.instance.WaveNumber + 1), 2);
    }

    public void ShowMessage(string message)
    {
        panel.SetActive(true);
        text.text = message;
    }

    private void WaveFinishedMessage()
    {
        ShowMessageForSeconds("Wave completed", 2);
    }

    public void ShowMessageForSeconds(string message, int seconds)
    {
        StartCoroutine(ShowMessage(message, seconds));
    }

    private IEnumerator ShowMessage(string message, int seconds)
    {
        GameObject messageObject = Instantiate(textMessagePrefab, panel.transform.position, Quaternion.identity, gameObject.transform);
        messageObject.GetComponentInChildren<TMP_Text>().text = message;
        yield return new WaitForSeconds(seconds);
        Destroy(messageObject);
    }
}
