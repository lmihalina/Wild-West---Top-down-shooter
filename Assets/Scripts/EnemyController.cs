using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //movement
    public float Distance = 5f;
    public float Velocity = 1f;
    public Vector2 Direction = Vector2.left;
    private float DistanceTraveled = 0;
    private bool IsDead = false;

    //break
    private float RemainingBreakTime = 0f;
    private int PatrolsUntilBreak;

    //attack player on sight
    private readonly Vector2[] sightDirections = new Vector2[5];

    //components
    Rigidbody2D rb;
    Gun gun;
    Health health;
    Animator animator;
    BoxCollider2D boxCollider;

    //lifecycle methods
    private void Start()
    {
        Direction.Normalize();
        RecalculateSightDirections();
        PatrolsUntilBreak = Random.Range(1, 7 + 1);

        rb = GetComponent<Rigidbody2D>();
        gun = GetComponent<Gun>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        boxCollider = GetComponent<BoxCollider2D>();

        health.OnHit += () => animator.SetTrigger("IsHit");
        health.OnDeath += () => { animator.SetTrigger("IsDead"); IsDead = true; boxCollider.enabled = false; };
    }
    private void FixedUpdate()
    {
        if(IsDead) 
            return;

        if (RemainingBreakTime > 0)
        {
            UseBreak();
        }
        else
        {
            Patrol();
            WaitForBreak();
        }
        AttackPlayerOnSight();
    }

    //internal logic
    private void Patrol()
    {
        if (DistanceTraveled < Distance)
        {
            float movementDistance = Velocity * Time.fixedDeltaTime;
            DistanceTraveled += movementDistance;
            Vector2 newPosition = rb.position + Direction * movementDistance;
            rb.MovePosition(newPosition);

            animator.SetFloat("Look X", Direction.x);
            animator.SetFloat("Look Y", Direction.y);
            animator.SetFloat("Velocity", Direction.sqrMagnitude);
        }
        else
        {
            Direction = -Direction;
            DistanceTraveled = 0;
            RecalculateSightDirections();
        }
    }
    private void WaitForBreak()
    {
        if(DistanceTraveled > Distance) // patrol over, about to turn around
        {
            PatrolsUntilBreak--;
        }

        if (PatrolsUntilBreak == 0)
        {
            PatrolsUntilBreak = Random.Range(1, 7 + 1);
            RemainingBreakTime = Random.Range(1, 4 + 1);
        }
    }
    
    private void UseBreak()
    {
        RemainingBreakTime -= Time.fixedDeltaTime;
        animator.SetFloat("Velocity", 0);
    }

    private void AttackPlayerOnSight()
    {
        foreach(Vector2 direction in sightDirections)
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, 4f, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                gun.Shoot(rb.position, direction);
                break;
            }
        }
    }

    //helpers
    private Vector2 RotateVector(Vector2 v, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        return new Vector2(v.x * cos - v.y * sin, v.x * sin + v.y * cos);
    }

    private void RecalculateSightDirections()
    {
        sightDirections[0] = Direction;
        sightDirections[1] = RotateVector(Direction, 30);
        sightDirections[2] = RotateVector(Direction, -30);
        sightDirections[3] = RotateVector(Direction, 60);
        sightDirections[4] = RotateVector(Direction, -60);
    }
}

