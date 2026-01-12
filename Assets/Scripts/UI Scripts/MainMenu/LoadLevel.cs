using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(gameObject.name);
    }
    
}
