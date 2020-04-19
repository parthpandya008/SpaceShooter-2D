using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Player Properties", menuName = "ScriptableObject/Player")]
public class PlayerData : ScriptableObject
{
    public int levelNo;
    public int playerTotalHealth; // Player's total health   

    //Fire rate of the weapon
    public float fireRate;
   
    //Screen move limit   
    public float moveSensitivity;
}
