using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour, IObjectPool
{
    [SerializeField]
    private Rigidbody2D bulletRigidBody;
    [SerializeField]
    private WeaponData bulletData;
    [SerializeField]
    private string playerTag;

    public void OnObjectSpawn()
    {
        Fire();
    }

    private void Fire()
    {
        bulletRigidBody.AddRelativeForce(Vector2.down*bulletData.speed, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        DisableBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        //Check for player and damge it's health
        if (collision.tag.Equals(playerTag))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            playerController.TakeDamage(bulletData.damage);
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
