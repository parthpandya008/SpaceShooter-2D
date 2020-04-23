using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Power Properties", menuName = "ScriptableObject/Power")]
public class PowerData: ScriptableObject
{
    public PowerType powerType;
    public int value;
}

public enum PowerType
{
    Health
}
