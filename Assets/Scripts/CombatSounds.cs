using UnityEngine;

public class CombatSounds : MonoBehaviour
{
    //audio clips
    public AudioClip[] ShootSounds;
    public AudioClip[] HitSounds;
    public AudioClip[] DeathSounds;

    //components
    private AudioSource audioSource;
    private Health health;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();   
        health = GetComponent<Health>();
    }

    private void Start()
    {
        health.OnDeath += PlayDeathSound;
        health.OnHit += PlayHitSound;
    }

    //API
    public void PlayShootSound()
    {
        int index = Random.Range(0, ShootSounds.Length);
        audioSource.PlayOneShot(ShootSounds[index]);
    }

    public void PlayHitSound()
    {
        int index = Random.Range (0, HitSounds.Length);
        audioSource.PlayOneShot(HitSounds[index]);
    }

    public void PlayDeathSound()
    {
        int index = Random.Range (0, DeathSounds.Length);
        audioSource.PlayOneShot(DeathSounds[index]);
    }
}
