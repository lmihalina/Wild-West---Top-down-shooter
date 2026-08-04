using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    //properties
    private int _MaxHealth = 100;
    public int MaxHealth
    {
        get => _MaxHealth;
        set
        {
            if ( CurrentHealth == _MaxHealth)
                CurrentHealth = value;
            _MaxHealth = value;
        }
    }

    public int CurrentHealth { get; private set; }
    public event Action OnDeath;
    public event Action OnHit;
    public event Action OnHeal;

    //components

    //lifecycle methods
    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    //API
    public void IncreaseHealth(int health)
    {
        if (CurrentHealth + health <= MaxHealth)
        {
            CurrentHealth += health;
            OnHeal?.Invoke();
        }
        else if (CurrentHealth + health > MaxHealth && CurrentHealth < MaxHealth)
        {
            CurrentHealth = MaxHealth;
            OnHeal?.Invoke();
        }
    }

    public void DecreaseHealth(int health)
    {
        if (CurrentHealth - health > 0)
        {
            CurrentHealth -= health;
            OnHit?.Invoke();
        }
        else
        {
            CurrentHealth = 0;
            OnDeath?.Invoke();
        }
    }
}
