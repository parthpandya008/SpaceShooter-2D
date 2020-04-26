using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerController : MonoBehaviour, IPower, IObjectPool
{
    [SerializeField]
    private PowerData healthProperTies;

    private void OnBecameInvisible()
    {
        DisablePower();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
             ConsumePower(GameManager.Instance.PlayerController);            
        }
    }

    public void OnObjectSpawn()
    {
        
    }

    public void ConsumePower(PlayerController obj)
    {
        obj.TakeDamage(-healthProperTies.value);
        DisablePower();
    }

    public void DisablePower()
    {
        this.gameObject.SetActive(false);
    } 
}
