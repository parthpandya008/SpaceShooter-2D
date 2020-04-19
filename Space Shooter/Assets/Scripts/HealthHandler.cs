using UnityEngine;
using System;

[Serializable]
public class HealthHandler
{
    [SerializeField]
    private int currentHealth;

    public int CurrentHealth => currentHealth;

    public event Action OnDied;

    public HealthHandler(int health)
    {
        currentHealth = health;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        OnDied();
    }
}
