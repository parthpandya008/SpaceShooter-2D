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

    [SerializeField]
    private string enemyTag;
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
        health.OnDied += OnPlayerDied;
        weaponFactory = new WeaponFactory();

        IntializeStateMachine();
    }

    private void Start()
    {
        SetMoveLimmit();
    }

    /// <summary>
    /// Set move limmit in horizontal and verticle, so player's ship can't go outside 
    /// </summary>
    private void SetMoveLimmit()
    {       
        minMoveX = -9;
        maxMoveX = 9; 
        minMoveY = -4;
        maxMoveY = 6;
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
       
        stateMachine.ChangeNextState(typeof(PlayerIdleState));
        Invoke("SetFireState", 1);
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
        health.OnDied -= OnPlayerDied;
    }

    /// <summary>
    /// Change the current state
    /// </summary>
    /// <param name="state"></param>
    private void OnStateChange(BaseState state)
    {
        currentStateName = state.GetType().Name;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals(enemyTag))
        {
            health.TakeDamage(1);
        }
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
}
