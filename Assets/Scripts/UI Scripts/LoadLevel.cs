using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(gameObject.name);
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
