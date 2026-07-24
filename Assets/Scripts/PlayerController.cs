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
    private Vector2 Direction = new Vector2(0,1);
    private bool IsDead = false;

    //components
    private Rigidbody2D rb;
    private Gun gun;
    private Health health;
    private Animator animator;
    private BoxCollider2D boxCollider;

    //lifecycle methods
    private void Start()
    {
        MoveAction.Enable();
        ShootAction.Enable();

        rb = GetComponent<Rigidbody2D>();
        gun = GetComponent<Gun>();
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        health.OnDeath += () => { animator.SetTrigger("IsDead"); IsDead = true; boxCollider.enabled = false; };
        health.OnHit += () => animator.SetTrigger("IsHit");
    }

    private void Update()
    {
        if(IsDead)
            return; 

        Movement = MoveAction.ReadValue<Vector2>();
        if(!Mathf.Approximately(Movement.sqrMagnitude, 0.0f))
        {
            Direction = Movement;
            animator.SetFloat("Look X", Direction.x);
            animator.SetFloat("Look Y", Direction.y);
        }
        animator.SetFloat("Velocity", Movement.sqrMagnitude);

        if (ShootAction.WasPressedThisFrame())
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
