using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler 
{
    /// <summary>
    /// Int variable
    /// </summary>
    private int score, bestScore; //Holds score of the Game

    public int Score => score;
    public int BestScore => bestScore;

    public ScoreHandler(int best)
    {
        bestScore = best;

        GameManager.Instance.GameStart += OnGameStart;
    }

    ~ScoreHandler()
    {
        GameManager.Instance.GameStart -= OnGameStart;
    }

    private void OnGameStart()
    {
        score = 0;
    }

    /// <summary>
    /// To Update the score in UI
    /// </summary>
    public void UpdateScore(int value)
    {
        score += value;
    }

    /// <summary>
    /// Check for the best score
    /// </summary>
    /// <returns></returns>
    public bool CheckBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            return true;
        }
        return false;
    }
}
