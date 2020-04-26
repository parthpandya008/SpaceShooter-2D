using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : BaseEnemy
{
    public override string Name => "BossEnemy";

    public override EnemyType Type => EnemyType.Boss;

    /// <summary>
    /// Instantiate Normale enemy
    /// </summary>
    public override void Instantiate()
    {
       GameObject enemy = ObjectPooler.Instance.SpwanFrompool("BossEnemyShip");
        enemy.transform.localEulerAngles = Vector3.zero;
        enemy.transform.localPosition = new Vector2(0, 7);
    }
}
