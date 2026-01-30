using UnityEngine;

public class ProjectileData : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public int power;
    public delegate void OnTargetHit(GameObject target);
    public OnTargetHit onTargetHit;

    public void AddEffectToProjectile(OnTargetHit onTargetHit)
    {
        this.onTargetHit = onTargetHit;
    }
}
