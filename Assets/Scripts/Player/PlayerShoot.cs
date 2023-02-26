using UnityEngine;

public class PlayerShoot : MonoBehaviour 
{
 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int damage = 1;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform shootSpot;
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        
        var shotLaser = Instantiate(bulletPrefab, shootSpot.position, Quaternion.identity);
        shotLaser.GetComponent<Rigidbody>().velocity = cameraTransform.forward * projectileSpeed;
        shotLaser.GetComponent<PlayerProjectile>().damage = damage;
    }
}