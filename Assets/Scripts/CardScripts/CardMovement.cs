using UnityEngine;

public class CardMovement : MonoBehaviour
{
    private const float cardSpeed = 10f;
    private Vector3 offset;
    private const int cardsInARow = 11;
    private const float cardSizeX = 1.7f;
    private const float cardSizeY = 2.5f;

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
        int totalcards = gameObject.transform.parent.childCount;
        int index = transform.GetSiblingIndex();
        int positionInRow = index % cardsInARow + 1;
        int numberOfRows = totalcards / cardsInARow + ((totalcards % cardsInARow) > 0 ? 1 : 0);
        int ownRow = index / cardsInARow + 1;
        int cardsInOwnRow = ownRow < numberOfRows ? cardsInARow : ((totalcards % cardsInARow) != 0 ? (totalcards % cardsInARow) : cardsInARow);

        float xValue = (positionInRow - (float)cardsInOwnRow / 2 - 0.5f) * cardSizeX;
        float yValue = (int)(index / cardsInARow) * cardSizeY;

        return new Vector3(xValue, yValue, 0) + offset;
    }
}
