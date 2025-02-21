using UnityEngine;
using UnityEngine.Rendering;

public class Cursor : MonoBehaviour
{
    Vector3 pos;
    public float speed = 1f;

    void Update()
    {
        pos = Input.mousePosition;
        pos.z = speed;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
