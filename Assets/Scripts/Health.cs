using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    //properties
    public int MaxHealth = 100;
    public int CurrentHealth { get; private set; }
    public event Action OnDeath;

    //lifecycle methods
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    //API
    public void IncreaseHealth(int health)
    {
        if (CurrentHealth + health < MaxHealth)
            CurrentHealth += health;
        else
            CurrentHealth = MaxHealth;
    }

    public void DecreaseHealth(int health)
    {
        if(CurrentHealth - health > 0)
            CurrentHealth -= health;
        else
        {
            CurrentHealth = 0;
            OnDeath.Invoke();
        }
    }
}
