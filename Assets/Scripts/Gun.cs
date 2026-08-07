using UnityEngine;

public class Gun : MonoBehaviour
{
    //properties
    public GameObject BulletPrefab;
    public float ShootingCooldown = 2f;
    private float Cooldown = 0;

    //components
    private Collider2D[] shooterColliders;
    private CombatSounds combatSounds;
    private Animator animator;

    //lifecycle methods
    private void Start()
    {
        shooterColliders = GetComponents<Collider2D>();
        animator = GetComponent<Animator>();
        combatSounds = GetComponent<CombatSounds>();
    }

    void Update()
    {
        if (Cooldown - Time.deltaTime > 0)
            Cooldown -= Time.deltaTime;
        else
            Cooldown = 0;
    }

    //API
    public void Shoot(Vector2 position, Vector2 direction)
    {
        if(Cooldown == 0)
        {
            Cooldown = ShootingCooldown;
            animator?.SetTrigger("IsShooting");
            combatSounds.PlayShootSound();

            GameObject bulletObject = Instantiate(BulletPrefab, position, Quaternion.identity);
            CircleCollider2D bulletCollider = bulletObject.GetComponent<CircleCollider2D>();
            foreach (var col in shooterColliders)
            {
                Physics2D.IgnoreCollision(col, bulletCollider);
            }

            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.Launch(direction, 10);
            
        }
    }
}
