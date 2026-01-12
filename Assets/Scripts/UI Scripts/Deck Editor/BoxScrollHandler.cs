using UnityEngine;

public class BoxScrollHandler : MonoBehaviour
{
    private float scale = 10f;
    private GameObject firstChild;
    private GameObject lastChild;
    private const float firstPosition = -70f;
    private const float lastPosition = -820f;

    private void OnEnable()
    {
        BoxHandler.OnCardsShown += GetChildren;
    }

    private void OnDisable()
    {
        BoxHandler.OnCardsShown -= GetChildren;
    }

    private void GetChildren()
    {
        firstChild = transform.GetChild(0).gameObject;
        lastChild = transform.GetChild(transform.childCount - 1).gameObject;
    }

    private void OnGUI()
    {
        if (Input.mouseScrollDelta.y == 0)
            return;
        
        if (!((firstChild.GetComponent<RectTransform>().anchoredPosition.y <= firstPosition && Input.mouseScrollDelta.y > 0) || (lastChild.GetComponent<RectTransform>().anchoredPosition.y >= lastPosition && Input.mouseScrollDelta.y < 0)))
            BroadcastMessage("ChangeYOffset", Input.mouseScrollDelta.y * scale);
    }
}
