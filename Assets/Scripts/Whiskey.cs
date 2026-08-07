using UnityEngine;

public class Whiskey : MonoBehaviour
{
    //properties
    public AudioClip drinkSound;

    private Vector2 Direction = Vector2.up;
    private float Distance = 0.25f;
    private float CurrentDistance = 0f;

    //lifecycle methods
    private void Update()
    {
        //glow / slightly move logic
        if(CurrentDistance < Distance)
        {
            float movement = Distance * Time.deltaTime; // takes 1s to move whole distance
            transform.position = transform.position + (Vector3)Direction * movement;
            CurrentDistance += movement;
        }
        else
        {
            CurrentDistance = 0;
            Direction = -Direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource audioSource = collision.GetComponent<AudioSource>();
        Health health = collision.GetComponent<Health>();

        //cant use onHeal because collding while HP is full assigns same event handler multiple times which creates issues(calling destroy on destroyed object)
        if (health.CurrentHealth < health.MaxHealth)
        {
            audioSource.PlayOneShot(drinkSound);
            health.IncreaseHealth(50);
            Destroy(gameObject);
        }
    }
}
