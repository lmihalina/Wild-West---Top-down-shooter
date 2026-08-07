using UnityEngine;

public class Bullet : MonoBehaviour
{
    //properties
    private Vector2 startingPosition;

    //components
    private Rigidbody2D rb;

    //lifecycle methods
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
    }

    private void Update()
    {
        if ((startingPosition - rb.position).sqrMagnitude > 100)
            Destroy(gameObject);
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
