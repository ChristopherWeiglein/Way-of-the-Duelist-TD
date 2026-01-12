using UnityEngine;

public class ChainLinkPlacement : MonoBehaviour
{
    private float size = 60;
    private float xValue = 0;

    private void Update()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(xValue, -30 - transform.GetSiblingIndex() * size);
    }
}
