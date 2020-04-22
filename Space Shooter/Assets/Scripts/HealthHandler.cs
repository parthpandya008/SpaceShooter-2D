using UnityEngine;
using System;

[Serializable]
public class HealthHandler
{
    [SerializeField]
    private int currentHealth;

    public int CurrentHealth => currentHealth;

    public event Action Died;

    public event Action<int> HealthUpdate;

    public HealthHandler(int health)
    {
        currentHealth = health;
    }

    /// <summary>
    /// Reset the health for the next object
    /// </summary>
    /// <param name="health"> Total Health</param>
    public void ResetCurrentHealth(int health)
    {
        currentHealth = health;
    }

    /// <summary>
    /// Take damage from opponent's weapon
    /// </summary>
    /// <param name="amount">damage amount</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        HealthUpdate?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        Died?.Invoke();
    }
}
