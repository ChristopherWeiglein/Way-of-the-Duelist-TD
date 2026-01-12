using UnityEngine;

public class ExitLevelSelection : MonoBehaviour
{
    [SerializeField] private GameObject selectLevel;
    public void ExitScene()
    {
        selectLevel.SetActive(false);
    }
    
}
