using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    private ProjectileData projectileData;
    private void Start()
    {
        projectileData = gameObject.GetComponent<ProjectileData>();
    }

    void Update()
    {
        try
        {
            transform.position = Vector3.MoveTowards(transform.position, projectileData.target.transform.position, Time.deltaTime * projectileData.speed);
        }
        catch
        {
            Destroy(gameObject);
        }
    }

}
