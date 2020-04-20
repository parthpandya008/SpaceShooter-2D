using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Custom Class Vars

    [Header("Properties")]
    [SerializeField]
    private EnemyData enemyProperties;
    [SerializeField]
    private HealthHandler health;

    [SerializeField]
    private Rigidbody2D enemyRigidBody2D;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 pos = enemyRigidBody2D.position + (Vector2.down * enemyProperties.moveSpeed* Time.deltaTime);
        enemyRigidBody2D.MovePosition(pos);
    }
}
