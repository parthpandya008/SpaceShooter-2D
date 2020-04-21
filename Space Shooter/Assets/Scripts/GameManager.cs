using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// Float variables
    /// </summary>
    private float minX, maxX, minY, maxY;

    #region

    public float MinX => minX;
    public float MaxX => maxX;
    public float MinY => minY;
    public float MaxY => maxY;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        SetScreenMinMaxPoints();
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
}
