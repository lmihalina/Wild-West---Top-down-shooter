using UnityEngine;

public class Gun : MonoBehaviour
{
    //properties
    public GameObject BulletPrefab;
    public float ShootingCooldown = 2f;

    private float Cooldown = 0;
    
    //lifecycle methods
  
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
            GameObject bulletObject = Instantiate(BulletPrefab, position, Quaternion.identity);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.Launch(direction, 10);
            Cooldown = ShootingCooldown;
        }
    }
}
