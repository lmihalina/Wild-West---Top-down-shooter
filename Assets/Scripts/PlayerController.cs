using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //input actions
    public InputAction MoveAction;
    public InputAction ShootAction;

    //properties
    public float Speed = 3f;
    private Vector2 Movement;
    private Vector2 Direction = new Vector2(1,0);

    //components
    private Rigidbody2D rb;
    private Gun gun;

    //lifecycle methods
    private void Start()
    {
        MoveAction.Enable();
        ShootAction.Enable();

        rb = GetComponent<Rigidbody2D>();
        gun = GetComponent<Gun>();
    }

    private void Update()
    {
        Movement = MoveAction.ReadValue<Vector2>();
        if(!Mathf.Approximately(Movement.sqrMagnitude, 0.0f))
        {
            Direction = Movement;
        }


        if(ShootAction.WasPressedThisFrame())
        {
            gun.Shoot(rb.position, Direction);
        }
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = (Vector2) rb.position + Movement * Speed * Time.fixedDeltaTime;        
        rb.MovePosition(newPosition);
    }
}
