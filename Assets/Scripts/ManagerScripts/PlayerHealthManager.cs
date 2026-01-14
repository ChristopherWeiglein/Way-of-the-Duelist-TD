using TMPro;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager instance;

    private int playerHealth = 8000;

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

    public void ChangePlayerHealth(int change)
    {
        playerHealth += change;
        gameObject.GetComponent<TMP_Text>().text = "LP: " + playerHealth.ToString();
        if (playerHealth <= 0)
            GameOverManager.GameOver();
    }
}
