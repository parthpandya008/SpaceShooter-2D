using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyType currentSpwanEnemy;

    [SerializeField]
    private float generationRate;
    private float lastGeneratedTime;

    private bool generateEnemy;

    private EnemyFactory enemyFactory;
    private BaseEnemy normalEnemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyFactory = new EnemyFactory();
        normalEnemy = enemyFactory.GetEnemy(EnemyType.Normal);

        GameManager.Instance.GameStart += OnGameStart;
        GameManager.Instance.GameEnd += OnGameEnd;
    }

    private void Update()
    {
        if(generateEnemy)
        {
            if (Time.time > lastGeneratedTime + generationRate)
            {
                GenerateEnemy();
                lastGeneratedTime = Time.time;
            }
        }
        
    }

    private void GenerateEnemy()
    {
        normalEnemy.Instantiate();
    }

    private void OnDestroy()
    {
        GameManager.Instance.GameStart -= OnGameStart;
        GameManager.Instance.GameEnd -= OnGameEnd;
    }

    /// <summary>
    /// Stop enemy generation on game stop
    /// </summary>
    private void OnGameEnd()
    {
        generateEnemy = false;
    }

    /// <summary>
    /// Start enemy generation on game start
    /// </summary>
    private void OnGameStart()
    {
        generateEnemy = true;
        lastGeneratedTime = Time.time;
    }
}
