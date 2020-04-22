using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// Float variables
    /// </summary>
    private float minX, maxX, minY, maxY;

    #region

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private PlayerController playerController;

    private ScoreHandler scoreHandler;

    public Action GameStart, GameEnd;


    #region Get

    public float MinX => minX;
    public float MaxX => maxX;
    public float MinY => minY;
    public float MaxY => maxY;

   
    #endregion

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();

        SetScreenMinMaxPoints();
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        scoreHandler = new ScoreHandler(bestScore);
        CheckBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Set the min and max points of the screen for Player movement, enemy and power generation
    /// </summary>
    private void SetScreenMinMaxPoints()
    {
        Vector2 leftPoint = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = leftPoint.x + 1;
        minY = leftPoint.y + 1;
        maxX = rightPoint.x - 1;
        maxY = rightPoint.y - 1;
    }

    /// <summary>
    /// To Update the score in UI
    /// </summary>
    public void UpdateScore(int value = 1)
    {
        scoreHandler.UpdateScore(value);
        uiManager.UpdateScore(scoreHandler.Score);
        CheckBestScore();
    }

    private void CheckBestScore()
    {
        if(scoreHandler.CheckBestScore())
        {           
            PlayerPrefs.SetInt("BestScore", scoreHandler.BestScore);
            uiManager.UpdateBestScore(scoreHandler.BestScore);
        }
    }

    /// <summary>
    /// To Update Player Healh's in UI
    /// </summary>
    public void UpdatePlayerHealth(int value)
    {
       uiManager.UpdateHealth(value);
    }

    /// <summary>
    /// Trigger the game start event
    /// </summary>
    public void StartGame()
    {
        GameStart?.Invoke();
        UpdateScore(0);
    }

    /// <summary>
    /// Trigger the game over event
    /// </summary>
    public void EndGame()
    {
        GameEnd?.Invoke();
    }
}
