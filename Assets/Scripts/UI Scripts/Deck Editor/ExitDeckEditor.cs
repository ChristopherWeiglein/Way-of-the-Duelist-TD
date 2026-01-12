using UnityEngine;

public class ExitDeckEditor : MonoBehaviour
{
    [SerializeField] private GameObject deckEditor;

    public void CloseDeckEditor()
    {
        deckEditor.SetActive(false);
    }
}
