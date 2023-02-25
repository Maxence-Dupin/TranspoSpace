using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 5.0f;
    private void Start() 
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Health>().Damage(damage);
        }
    }
}