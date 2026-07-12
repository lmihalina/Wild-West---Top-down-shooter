using UnityEngine;

public class Bullet : MonoBehaviour
{
    //components
    private Rigidbody2D rb;

    //lifecycle methods
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //API
    public void Launch(Vector2 direction, float speed)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
