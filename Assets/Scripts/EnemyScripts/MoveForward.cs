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
        SetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (destination == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);
        distanceWalked += Time.deltaTime * speed;
    }

    private void OnEnable()
    {
        stats.OnStatusReceived += SetSpeed;
    }

    private void OnDisable()
    {
        stats.OnStatusReceived -= SetSpeed;
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

    private void SetSpeed()
    {
        speed = (1 + ((float)stats.MonsterInfo.level / 4)) * (stats.activeStatuses.Contains(EnemyDataTypes.EnemyStatus.Negated) ? 0.8f : 1);
    }
}
