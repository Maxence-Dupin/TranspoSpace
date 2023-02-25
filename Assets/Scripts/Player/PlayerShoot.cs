using UnityEngine;

public class PlayerShoot : MonoBehaviour 
{
 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int damage = 1;
    [SerializeField] private float projectileSpeed;
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        
        var shotLaser = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        shotLaser.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
        shotLaser.GetComponent<EnemyLaser>().damage = damage;
    }
}