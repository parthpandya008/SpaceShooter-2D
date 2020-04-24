using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    [SerializeField]
    private PowerType currentPowerType;

    [SerializeField]
    private float generationRate;
    private float lastGeneratedTime;

    private bool generatePower;

    private void Start()
    {
        GameManager.Instance.GameStart += OnGameStart;
        GameManager.Instance.GameEnd += OnGameEnd;
    }

    private void Update()
    {
        if(generatePower)
        {
            if (Time.time > lastGeneratedTime + generationRate)
            {
                GeneratePower();
                lastGeneratedTime = Time.time;
            }
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameStart -= OnGameStart;
            GameManager.Instance.GameEnd -= OnGameEnd;
        }
    }

    private void GeneratePower()
    {
        GameObject powerObject = null;
        switch(currentPowerType)
        {
            case PowerType.Health:
                powerObject = ObjectPooler.Instance.SpwanFrompool("HealthPower");
                break;   
        }
        if(powerObject != null)
        {
            powerObject.transform.localEulerAngles = Vector3.zero;
            powerObject.transform.localPosition = new Vector2(Random.Range(GameManager.Instance.MinX, GameManager.Instance.MaxX), 7);
        }
    }

    /// <summary>
    /// Stop enemy generation on game stop
    /// </summary>
    private void OnGameEnd()
    {
        generatePower = false;
    }

    /// <summary>
    /// Start enemy generation on game start
    /// </summary>
    private void OnGameStart()
    {
        generatePower = true;
        lastGeneratedTime = Time.time;
    }
}
