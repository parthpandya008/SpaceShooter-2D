using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour, IObjectPool, IEnemy
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

    [SerializeField]
    private AudioSource audioSource;

    private float lastBulletTime;

    private int dist = 90;
    private int start = -45;

    #endregion

    #region Get
    public EnemyData EnemyProperties => enemyProperties;
    #endregion

    private void Start()
    {
        health = new HealthHandler(enemyProperties.totalHealth);
        health.Died += OnDied;

        GameManager.Instance.GameEnd += OnGameEnd;
        Invoke("DisbaleEnemy", 15);
    }

    /// <summary>
    /// Rest required properties on re spwaing
    /// </summary>
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
        Vector2 pos = enemyRigidBody2D.position;
        if(pos.y > 1)
        {
            pos = pos + (Vector2.down * enemyProperties.moveSpeed * Time.deltaTime);
            enemyRigidBody2D.MovePosition(pos);
        } 
    }

    private void OnBecameInvisible()
    {
        DisbaleEnemy();
    }

    private void OnDestroy()
    {
        health.Died -= OnDied;

        if(GameManager.Instance != null)
            GameManager.Instance.GameEnd -= OnGameEnd;
    }

    /// <summary>
    /// Disable enemy on game end
    /// </summary>
    private void OnGameEnd()
    {
        DisbaleEnemy();
    }

    /// <summary>
    /// Disable enemy
    /// </summary>
    public void DisbaleEnemy()
    {
        this.gameObject.SetActive(false);
    }


    /// <summary>
    /// Generate Bullet
    /// </summary>
    public void GenerateBullet()
    {
       GameObject bullet = ObjectPooler.Instance.SpwanFrompool("EnemyBullet");
        bullet.transform.localEulerAngles = Vector3.zero;
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.localScale = Vector2.one * 3;
    }

    /// <summary>
    /// Take damage from Player
    /// </summary>
    /// <param name="val">damage values</param>
    public void TakeDamage(int val)
    {
        health.TakeDamage(val);
    }

    /// <summary>
    /// Exlpode boss enemy
    /// </summary>
    private void OnDied()
    {
        GameObject explossion = ObjectPooler.Instance.SpwanFrompool("EnemyExplossion");
        explossion.transform.position = transform.position; ObjectPooler.Instance.SpwanFrompool("EnemyExplossion");
        DisbaleEnemy(); 
    }
}
