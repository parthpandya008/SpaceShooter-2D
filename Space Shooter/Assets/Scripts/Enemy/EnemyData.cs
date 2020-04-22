using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Enemy Properties", menuName = "ScriptableObject/Enemy")]
public class EnemyData : ScriptableObject
{
    public int levelNo;
    public int totalHealth; // Player's total health   

    //Screen move limit   
    public float moveSpeed;

    public int damageValue;

    public WeaponData bulletData;
}