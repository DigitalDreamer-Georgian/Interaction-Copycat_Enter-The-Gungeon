using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, maxHealth = 2;
    public float speed;
    public Transform target;
    public float minimumDistance;
    public float proximityDistance;
    public GameObject bulletPrefab;
    public float cooldown;
    public float nextShot;

    private void Start()
    {
        health = maxHealth;
    }
    private void Update()
    {
        if (health <= 0) Destroy(gameObject);

        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget > minimumDistance)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (distanceToTarget <= proximityDistance && Time.time > nextShot)
            AimAndShoot();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void AimAndShoot()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.linearVelocity = direction * speed;

        nextShot = Time.time + cooldown;
    }
}
