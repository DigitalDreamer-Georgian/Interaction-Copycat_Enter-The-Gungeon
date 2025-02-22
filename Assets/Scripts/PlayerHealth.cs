using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private float health = 4f;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private Transform respawn;

    private void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Respawn();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }

        if (health <= 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        health = maxHealth;
        if (respawn != null)
        {
            transform.position = respawn.position;
        }
    }
}
