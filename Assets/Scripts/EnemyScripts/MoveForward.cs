using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 1;
    private float distanceWalked = 0;
    [SerializeField] private EnemyInfo stats;
    private GameObject destination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Mathf.Pow(1.2f, 1000f / ((float)stats.MonsterInfo.defense + 100f)) / ((float)stats.MonsterInfo.level / 2); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (destination == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);
        distanceWalked += Time.deltaTime * speed;
    }

    public void SetNewDestination(GameObject destination)
    {
        this.destination = destination;
    }

    public float GetDistance() => distanceWalked;

    public void SetBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, -speed * Time.deltaTime * 20);
        distanceWalked -= speed * Time.deltaTime * 20;
    }
}
