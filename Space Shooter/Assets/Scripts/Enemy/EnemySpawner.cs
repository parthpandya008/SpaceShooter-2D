using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    //Wave lenght to generate the boss enemy
    [SerializeField]
    private int waveLenght;
    [SerializeField]
    private int generatedEnemyCount;

    //Rate to generate different kind of enemy
    [SerializeField]
    private float generationRate;

    [SerializeField]
    private EnemyType currentSpwanEnemy;
    
    private float lastGeneratedTime;

    private bool generateEnemy;

    //Factory referance of enemy
    private EnemyFactory enemyFactory;
    private BaseEnemy normalEnemy, bossEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        //Create instance of the different kind of the enemies
        enemyFactory = new EnemyFactory();
        normalEnemy = enemyFactory.GetEnemy(EnemyType.Normal);
        bossEnemy = enemyFactory.GetEnemy(EnemyType.Boss);

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

    /// <summary>
    /// Generate different enemies
    /// </summary>
    private void GenerateEnemy()
    {
        generatedEnemyCount++;
        switch (currentSpwanEnemy)
        {
            case EnemyType.Normal:
                normalEnemy.Instantiate();
                break;
            case EnemyType.Boss:
                bossEnemy.Instantiate();
                currentSpwanEnemy = EnemyType.Normal;
                break;
        }
        if (generatedEnemyCount % waveLenght == 0)
        {
            currentSpwanEnemy = EnemyType.Boss;
        }
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null)
        {        
            GameManager.Instance.GameStart -= OnGameStart;
            GameManager.Instance.GameEnd -= OnGameEnd;
        }
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
        generatedEnemyCount = 0;
    }
}
