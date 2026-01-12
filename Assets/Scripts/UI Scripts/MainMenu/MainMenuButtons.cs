using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject deckEditor;
    [SerializeField] private GameObject selectLevel;
    public void SelectLevel()
    {
        selectLevel.SetActive(true);
    }

    public void Shop()
    {

    }

    public void DeckEditor()
    {
        deckEditor.SetActive(true);
    }

    public void Options()
    {

    }

    public void ExitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
