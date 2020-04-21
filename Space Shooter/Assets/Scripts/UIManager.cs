using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Text Component
    [SerializeField]
    private Text txtScore, txtHealth, txtGO, txtBestScore;
    // Start is called before the first frame update
    void Start()
    {
        
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

}
