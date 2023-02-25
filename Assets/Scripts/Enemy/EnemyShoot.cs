using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public int damage = 1;
    [SerializeField] private float distanceAggro = 10f;
    [SerializeField] private Transform shootSpot;
    [SerializeField] private GameObject laser;
    private Transform _player;

    [SerializeField] private float projectileSpeed = 1f;

    [SerializeField] private float reloadTime = 0.5f;
    private bool _reloading;

    private Vector3 _direction;
    private float _projectileAngle;

    private void Start() 
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() 
    {
        _direction = _player.position - shootSpot.position;
        _direction.Normalize();
        _projectileAngle = Vector3.SignedAngle(transform.right, _direction, Vector3.forward);

        if (Vector2.Distance(transform.position, _player.position) < distanceAggro && !_reloading) 
        {
            _reloading = true;
            var shotLaser = Instantiate(laser, shootSpot.position, Quaternion.Euler(0, 0, _projectileAngle));
            shotLaser.GetComponent<Rigidbody>().velocity = _direction * projectileSpeed;
            shotLaser.GetComponent<EnemyLaser>().damage = damage;
            StartCoroutine(WaitShoot());
        }
    }

    private IEnumerator WaitShoot() 
    {
        yield return new WaitForSeconds(reloadTime);
        _reloading = false;
    }
}