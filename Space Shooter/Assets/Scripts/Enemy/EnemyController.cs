using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IObjectPool
{
    #region Custom Class Vars

    [Header("Properties")]
    [SerializeField]
    private EnemyData enemyProperties;
    [SerializeField]
    private EnemyType enemyType;
    [SerializeField]
    private HealthHandler health;
    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private Rigidbody2D enemyRigidBody2D;

    [SerializeField]
    private string PlayerTag;

    [SerializeField]
    private float fireRate;

    private float lastBulletTime;

    #endregion

    private void Start()
    {
        health = new HealthHandler(enemyProperties.totalHealth);
        health.OnDied += OnDied;
    } 

    public void OnObjectSpawn()
    {
        health.ResetCurrentHealth(enemyProperties.totalHealth);
    }

    private void Update()
    {
        if(Time.time > lastBulletTime +fireRate)
        {
            GenerateBullet();
            lastBulletTime = Time.time;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 pos = enemyRigidBody2D.position + (Vector2.down * enemyProperties.moveSpeed* Time.deltaTime);
        enemyRigidBody2D.MovePosition(pos);
    }

    private void OnBecameInvisible()
    {
        DisbaleEnemy();
    }

    private void OnDestroy()
    {
        health.OnDied -= OnDied;
    }

    /// <summary>
    /// Disable enemy
    /// </summary>
    private void DisbaleEnemy()
    {
        this.gameObject.SetActive(false);
    }

    private void GenerateBullet()
    {
       GameObject bullet = ObjectPooler.Instance.SpwanFrompool("EnemyBullet");
        bullet.transform.localEulerAngles = Vector3.zero;
        bullet.transform.position = bulletSpawnPoint.position;
    }

    /// <summary>
    /// Take damage from Player
    /// </summary>
    /// <param name="val">damage values</param>
    public void TakeDamage(int val)
    {
        health.TakeDamage(val);
    }

    private void OnDied()
    {
        DisbaleEnemy(); 
    }
}
