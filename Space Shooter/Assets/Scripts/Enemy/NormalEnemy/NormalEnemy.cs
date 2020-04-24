using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : BaseEnemy
{
    public override string Name => "NormalEnemy";

    public override EnemyType Type => EnemyType.Normal;

    /// <summary>
    /// Instantiate Normale enemy
    /// </summary>
    public override void Instantiate()
    {
       GameObject enemy = ObjectPooler.Instance.SpwanFrompool("NormalEnemyShip");
        enemy.transform.localEulerAngles = Vector3.zero;
        enemy.transform.localPosition = new Vector2(Random.Range(GameManager.Instance.MinX, GameManager.Instance.MaxX), 7);
    }
}
