using System.Collections;
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
    public void setBulletSpeed(float speed, int damage = 1)
    {
        bulletSpeed = speed;
        damageValue = damage;
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
        //Check for the enemy and damge it's health
        if (collision.tag.Equals(enemyTag))
        {
            EnemyController enemyController = collision.GetComponent<EnemyController>();
            enemyController.TakeDamage(damageValue);
            GameManager.Instance.UpdateScore(1);
            DisableBullet();
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
