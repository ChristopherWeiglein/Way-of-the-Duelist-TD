using UnityEngine;

public class ShowRangeOnMouseHover : MonoBehaviour
{
    private SpriteRenderer rangeSprite;
    void Start()
    {
        rangeSprite = gameObject.transform.Find("Range").GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        rangeSprite.enabled = true;
    }

    private void OnMouseExit()
    {
        rangeSprite.enabled = false;
    }
}
