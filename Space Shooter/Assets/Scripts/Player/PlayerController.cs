using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region private Vars

    [SerializeField]
    private string currentStateName;

    [SerializeField]
    private StateMachine stateMachine;

    //[SerializeField]
    //private PlayerProperties playerProperties;

    #region Custom Class Vars

    [Header("Properties")]
    [SerializeField]
    private PlayerData playerProperties;
    [SerializeField]
    private HealthHandler health;

    [SerializeField]
    private InputController inputController;

    [SerializeField]
    private Transform bulletSpawnPoint;

    #endregion

    private WeaponFactory weaponFactory;
    #endregion

    #region public Vars        

    public bool movePlayer = false;

    public bool isPlayerOutOfScope = false;

    #endregion

    #region get

    public PlayerData PlayerProperties => playerProperties;

    public InputController InputController => inputController;

    public WeaponFactory WeaponFactory => weaponFactory;

    public Transform BulletSpwanPoint => bulletSpawnPoint;

    

    #endregion

    public float minMoveX, maxMoveX;
    public float minMoveY, maxMoveY;

    private void Awake()
    {
        health = new HealthHandler(PlayerProperties.playerTotalHealth);
        health.HealthUpdate += OnHealthUpdate;
        health.Died += OnPlayerDied;
        OnHealthUpdate(PlayerProperties.playerTotalHealth);
        weaponFactory = new WeaponFactory();

        IntializeStateMachine();
    }

    private void Start()
    {
        GameManager.Instance.GameStart += OnGameStart;
    }

    /// <summary>
    /// Set move limmit in horizontal and verticle, so player's ship can't go outside 
    /// </summary>
    private void SetMoveLimmit()
    {       
        minMoveX = GameManager.Instance.MinX;
        maxMoveX = GameManager.Instance.MaxX; 
        minMoveY = GameManager.Instance.MinY;
        maxMoveY = GameManager.Instance.MaxY;
    }

    /// <summary>
    /// Intilaize the State Machine for Player and feed all the states
    /// </summary>
    private void IntializeStateMachine()
    {
        stateMachine.OnStateChanged += OnStateChange;       
        var states = new Dictionary<Type, BaseState>();
        states.Add(typeof(PlayerIdleState), new PlayerIdleState(controller: this));
        states.Add(typeof(PlayerFireState), new PlayerFireState(controller: this));
        states.Add(typeof(PlayerMoveState), new PlayerMoveState(controller: this));
        states.Add(typeof(PlayerDeathState), new PlayerDeathState(controller: this));            
        stateMachine.SetAvailableStates(states); 
    }

    /// <summary>
    /// Set the fire state after some time, to run contineously with other state
    /// </summary>
    private void SetFireState()
    {
        stateMachine.SetContineousState(typeof(PlayerFireState));
    }

    /// <summary>
    /// Relase memory or any subscribed events
    /// </summary>
    private void OnDestroy()
    {
        stateMachine.OnStateChanged -= OnStateChange;
        health.Died -= OnPlayerDied;
        health.HealthUpdate -= OnHealthUpdate;

        if(GameManager.Instance != null)
            GameManager.Instance.GameStart -= OnGameStart;
    }

    /// <summary>
    /// On Game Start Callback
    /// </summary>
    private void OnGameStart()
    {
        SetMoveLimmit();
        gameObject.SetActive(true);
        stateMachine.ChangeNextState(typeof(PlayerIdleState));
        health.ResetCurrentHealth(playerProperties.playerTotalHealth);
        OnHealthUpdate(PlayerProperties.playerTotalHealth);
        Invoke("SetFireState", 1);
    }

    /// <summary>
    /// Change the current state
    /// </summary>
    /// <param name="state"></param>
    private void OnStateChange(BaseState state)
    {
        currentStateName = state.GetType().Name;
    } 

    /// <summary>
    /// Take damage from enemy
    /// </summary>
    /// <param name="val">damage value</param>
    public void TakeDamage(int val)
    {
        health.TakeDamage(val);
    }

    /// <summary>
    /// Change state on Player's deth
    /// </summary>
    private void OnPlayerDied()
    {     
        if (stateMachine.currentState.GetType() != typeof(PlayerDeathState))
        {
            stateMachine.ChangeNextState(typeof(PlayerDeathState));
        }
    }

    /// <summary>
    /// Update Health UI
    /// </summary>
    /// <param name="obj">health value</param>
    private void OnHealthUpdate(int obj)
    {
        GameManager.Instance.UpdatePlayerHealth(obj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemyController = collision.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.TakeDamage(playerProperties.dammageValue);
            GameManager.Instance.UpdateScore();
            TakeDamage(enemyController.EnemyProperties.damageValue);
        }
    }

    /// <summary>
    /// Disable the player on death
    /// </summary>
    public void DisablePlayer()
    {
        gameObject.SetActive(false);
    }
}
