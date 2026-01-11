using UnityEngine;

public class CardMovement : MonoBehaviour
{
    private const float cardSpeed = 10f;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.parent.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FindDestination(), Time.deltaTime * cardSpeed);
    }

    private Vector3 FindDestination()
    {
        int cardsInHand = gameObject.transform.parent.childCount;
        int index = transform.GetSiblingIndex();
        float cardSize = 1.7f;

        float xValue = (-1) * ((float)(1 + cardsInHand) / 2 - index - 1) * cardSize;

        return new Vector3(xValue, 0, 0) + offset;
    }
}
