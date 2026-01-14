using UnityEngine;

public class DeckEditorCardMovement : MonoBehaviour
{
    private const float speed = 500.0f;
    private const int cardsInARow = 10;
    [SerializeField] private float offsetX = 5f;
    [SerializeField] private float cardDistanceX = 60;
    [SerializeField] private float offsetY = -5f;
    [SerializeField] private float cardDistanceY = -85;

    private void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(GetComponent<RectTransform>().anchoredPosition, CalculatePosition(), speed * Time.deltaTime);
    }

    private Vector3 CalculatePosition()
    {
        float xValue = offsetX + (transform.GetSiblingIndex() % cardsInARow) * cardDistanceX;
        float yValue = offsetY + ((int)(transform.GetSiblingIndex() / cardsInARow)) * cardDistanceY;

        return new Vector3(xValue, yValue);
    }

    private void ChangeYOffset(float yValue)
    {
        offsetY -= yValue;
    }
}
