﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletObject : MonoBehaviour, IObjectPool
{
    [SerializeField]
    private Rigidbody2D bulletRigidBody;
    private int damageValue;
    private float bulletSpeed;
    [SerializeField]
    private string enemyTag;


    public void OnObjectSpawn()
    {
        //Fire();
    }
    /// <summary>
    /// Set the weapon data
    /// </summary>
    /// <param name="speed">speed of the bullet</param>
    /// <param name="damage">damage value of the weapon</param>
    public void setData(float speed, int damage = 1)
    {
        bulletSpeed = speed;
        damageValue = damage;
        Fire();
    }

    public void SetData(PlayerController controller)
    {
        bulletSpeed = controller.PlayerProperties.bulletData.speed;
        damageValue = controller.PlayerProperties.bulletData.damage;
        Fire();
    }

    /// <summary>
    /// Fire the bullet
    /// </summary>
    private void Fire()
    {
        bulletRigidBody.AddRelativeForce(Vector2.up*bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        DisableBullet();
    }

    
    /// <summary>
    /// Check the collision of the bullet with enemy
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check for the enemy and damge it's 
        //Debug.LogError(" Player bullet collision.tag " + collision.tag);
        if (collision.tag.Equals(enemyTag))
        {
            IEnemy enemy = collision.GetComponent<IEnemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damageValue);
                GameManager.Instance.UpdateScore();
                DisableBullet();
            }           
        }
    }


    /// <summary>
    /// Disable the object
    /// </summary>
    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
