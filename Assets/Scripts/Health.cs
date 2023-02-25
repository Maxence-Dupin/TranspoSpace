using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField] private float health = 5f;

    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            KillEntity();
        }
    }

    private void KillEntity()
    {
        Destroy(gameObject);

        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
} 
