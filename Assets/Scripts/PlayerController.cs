using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //input actions
    public InputAction MoveAction;

    //object properties
    public float Speed = 3f;
    private Vector2 Direction;

    //components
    private Rigidbody2D rb;

    //lifecycle methods
    private void Start()
    {
        MoveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Direction = MoveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = (Vector2) rb.position + Direction * Speed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
}
