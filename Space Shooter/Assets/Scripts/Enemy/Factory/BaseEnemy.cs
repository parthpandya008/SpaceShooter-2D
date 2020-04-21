
using UnityEngine;

public enum EnemyType
{
    None,
    Normal,
    MiniBoss,
    Boss,
    BigBoss
}

public abstract class BaseEnemy
{
    public abstract string Name { get; }
    public abstract EnemyType Type { get; }

    //Instantiate the Enemy from the factory
    public abstract void Instantiate();
}
