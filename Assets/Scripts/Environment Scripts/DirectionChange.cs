using UnityEngine;

public class DirectionChange : MonoBehaviour
{
    public float rotationAngle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.transform.Rotate(Vector3.forward, rotationAngle);
            collision.gameObject.transform.Find("Canvas").Rotate(Vector3.forward, rotationAngle * -1);
        }
    }
}
