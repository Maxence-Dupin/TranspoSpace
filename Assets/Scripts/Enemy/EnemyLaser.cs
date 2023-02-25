using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 5.0f;
    private void Start() 
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
        else if (collider.CompareTag("Boss")) 
        {
            Destroy(gameObject);
        }
        else if (!collider.isTrigger && !collider.CompareTag("Enemy")) 
        {
            Destroy(gameObject);
        }
    }
}