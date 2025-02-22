using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int dmg = 1;
    public LayerMask whatIsPlayer; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatIsPlayer) != 0)
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(dmg);
            }

            Destroy(gameObject); 
        }
    }
}

