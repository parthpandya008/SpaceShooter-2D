using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletObject : MonoBehaviour, IObjectPool
{
    [SerializeField]
    private Rigidbody2D bulletRigidBody;

    private float bulletSpeed;

    public void OnObjectSpawn()
    {
        //Fire();
    }

    public void setBulletSpeed(float speed)
    {
        bulletSpeed = speed;

        Fire();
    }

    private void Fire()
    {
        bulletRigidBody.AddRelativeForce(new Vector2(0, bulletSpeed), ForceMode2D.Impulse);

        Invoke("disableBullet", 2);
    }

    private void disableBullet()
    {
        gameObject.SetActive(false);
    }
}
