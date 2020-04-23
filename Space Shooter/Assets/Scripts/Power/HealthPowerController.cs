﻿using System.Collections;
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
        Debug.LogError(" collision.tag " + collision.tag);
        if (collision.tag.Equals("Player"))
        {
             ConsumePower(GameManager.Instance.PlayerController);            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError(""+ collision.transform.tag);    
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