using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //movement
    public float Distance = 5f;
    public float Velocity = 1f;
    public Vector2 Direction = Vector2.left;
    private float DistanceTraveled = 0;

    //break
    private float RemainingBreakTime = 0f;
    private int PatrolsUntilBreak;
   
    //components
    Rigidbody2D rb;

    //lifecycle methods
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Direction.Normalize();
        PatrolsUntilBreak = Random.Range(1, 7 + 1);
    }
    private void FixedUpdate()
    {
        if (RemainingBreakTime > 0)
        {
            RemainingBreakTime -= Time.fixedDeltaTime;
        }
        else
        {
            Patrol();
            WaitForBreak();
        }
        Debug.Log(PatrolsUntilBreak + ",  " + RemainingBreakTime + "s");
    }

    //internal logic
    private void Patrol()
    {
        if (DistanceTraveled < Distance)
        {
            float movementDistance = Velocity * Time.fixedDeltaTime;
            Vector2 newPosition = rb.position + Direction * movementDistance;

            RaycastHit2D obstacleInWay = Physics2D.Raycast(rb.position, Direction, movementDistance + 0.25f);
            if (obstacleInWay)
            {
                DistanceTraveled = Distance; // turn around next frame
            }
            else
            {
                DistanceTraveled += movementDistance;
                rb.MovePosition(newPosition);
            }
        }
        else
        {
            Direction = -Direction;
            DistanceTraveled = 0;
        }
    }
    private void WaitForBreak()
    {
        if (PatrolsUntilBreak == 0)
        {
            PatrolsUntilBreak = Random.Range(1, 7 + 1);
            RemainingBreakTime = Random.Range(1, 4 + 1);
        }

        if (DistanceTraveled >= Distance) //current patrol is finished
        {
            PatrolsUntilBreak--;
        }
    }   
}

