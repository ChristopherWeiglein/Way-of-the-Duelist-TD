using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 1;
    private float distanceWalked = 0;
    [SerializeField] private EnemyInfo stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Mathf.Pow(1.1f, stats.MonsterInfo.level);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        distanceWalked += Time.deltaTime * speed;
    }

    public float GetDistance() => distanceWalked;
}
