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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if(health != null)
        {
            health.DecreaseHealth(50);
        }
        Destroy(gameObject);
    }

    //API
    public void Launch(Vector2 direction, float speed)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
