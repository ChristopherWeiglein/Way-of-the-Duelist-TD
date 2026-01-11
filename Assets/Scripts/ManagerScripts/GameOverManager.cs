using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameOverManager 
{
    public static void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
