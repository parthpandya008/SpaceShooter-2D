using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Player Properties", menuName = "ScriptableObject/Player")]
public class PlayerData : ScriptableObject
{
    public int levelNo;
    public int playerTotalHealth; // Player's total health   
    public int dammageValue;

    //Screen move limit   
    public float moveSensitivity;
    public WeaponData bulletData;
}
