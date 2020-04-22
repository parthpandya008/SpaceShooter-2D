using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Text Component
    [SerializeField]
    private Text txtScore, txtHealth, txtGO, txtBestScore;

    [SerializeField]
    private GameObject playUIPanel;

    // Start is called before the first frame update
    private void Start()
    {
        GameManager.Instance.GameEnd += OnGameEnd;
    }

    private void OnGameEnd()
    {
        playUIPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.Instance.GameEnd -= OnGameEnd;
    }

    /// <summary>
    /// Update Score UI
    /// </summary>
    /// <param name="score"></param>
    public void UpdateScore(int score)
    {
        txtScore.text = score.ToString();
    }

    /// <summary>
    /// Update Best Score
    /// </summary>
    /// <param name="updateBestScore"></param>
	public void UpdateBestScore(int updateBestScore)
    {
        txtBestScore.text = updateBestScore.ToString();
    }

    /// <summary>
    /// Update Health
    /// </summary>
    /// <param name="halth"></param>
	public void UpdateHealth(int halth)
    {
        txtHealth.text = halth.ToString();
    }

    public void OnPlayButtonClicked()
    {
        GameManager.Instance.StartGame();
        playUIPanel.SetActive(false);
    }

}
