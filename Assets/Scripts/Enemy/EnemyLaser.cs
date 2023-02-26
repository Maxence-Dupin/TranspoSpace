using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 5.0f;
    private void Start() 
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider collider) 
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Enemy")) 
        {
            Destroy(gameObject);
            
            collider.GetComponent<Health>().Damage(damage);
        }
    }
}