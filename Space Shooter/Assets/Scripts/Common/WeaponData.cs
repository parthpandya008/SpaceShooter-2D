using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Weapon Properties", menuName = "ScriptableObject/Weapon")]
public class WeaponData : ScriptableObject
{
    public int level;
    public float fireRate;
    public float speed;
    public int damage;
}
