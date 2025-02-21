using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    float bulletSpeed = 10.0f;

    void Update()
    {
        // Aiming
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        mouse.z = 0.0f;
        Vector3 mouseDirection = (mouse - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + mouseDirection * 5.0f);

        // Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootGun(mouseDirection);
        }
    }

    void ShootGun(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position + direction * 0.75f;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bullet.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(bullet, 1.0f);
    }
}
