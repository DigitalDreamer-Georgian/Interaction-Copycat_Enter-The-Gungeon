using UnityEngine;
using System.Collections;

public class DodgeRoll : MonoBehaviour
{
    public float speed = 2.0f;
    public float rollSpeed = 5.0f;
    public float rollDuration = 0.3f;
    private Rigidbody2D rb;
    private Vector2 input;
    private bool Rolling = false;
    private bool Invincible = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!Rolling)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !Rolling)
        {
            StartCoroutine(RollDodge());
        }
    }

    private IEnumerator RollDodge()
    {
        Rolling = true;
        Invincible = true;
        StartCoroutine(Rotate());
        yield return new WaitForSeconds(rollDuration);
        Rolling = false;
        Invincible = false;
    }

    private IEnumerator Rotate()
    {
        float TimeAmount = 0f;
        float rotationSpeed = 180f / rollDuration;
        while (TimeAmount < rollDuration)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            TimeAmount += Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.identity; 
    }
}
