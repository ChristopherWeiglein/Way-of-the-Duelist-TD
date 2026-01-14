using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private float distanceWalked = 0;
    [SerializeField] private EnemyInfo stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Mathf.Pow(2f, 1000f / ((float)stats.MonsterInfo.defense + 100f)) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        distanceWalked += Time.deltaTime * speed;
    }

    public float GetDistance() => distanceWalked;
}
