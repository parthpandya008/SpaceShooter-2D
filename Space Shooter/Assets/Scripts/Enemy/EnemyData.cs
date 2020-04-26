using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Enemy Properties", menuName = "ScriptableObject/Enemy")]
public class EnemyData : ScriptableObject
{
    public int levelNo;
    public int totalHealth; // Player's total health   
    public int damageValue;

    //Screen move limit   
    public float moveSpeed;
    public float stopPoint;

    public EnemyType enemyType;

    public WeaponData bulletData;
}

public enum EnemyType
{
    None,
    Normal,
    MiniBoss,
    Boss,
    BigBoss
}