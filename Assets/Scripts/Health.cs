using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float health = 10f;

    private void Damage()
    {
        
    }

    private void KillEntity()
    {
        Destroy(gameObject);
    }
}
