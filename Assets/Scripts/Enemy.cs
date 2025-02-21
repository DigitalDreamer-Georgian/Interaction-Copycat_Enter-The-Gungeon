using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, maxHealth = 2;
    public float speed;

    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        damage = 1;
        health -= damage;
    }
}
