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

    private EnemyFactory enemyFactory;
    private BaseEnemy normalEnemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyFactory = new EnemyFactory();
        normalEnemy = enemyFactory.GetEnemy(EnemyType.Normal);

        lastGeneratedTime = Time.time;

    }

    private void Update()
    {
        if(Time.time > lastGeneratedTime + generationRate)
        {
            GenerateEnemy();
            lastGeneratedTime = Time.time;
        }
    }

    private void GenerateEnemy()
    {
        normalEnemy.Instantiate();

    }
}
