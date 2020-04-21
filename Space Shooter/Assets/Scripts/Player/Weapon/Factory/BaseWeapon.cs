
using UnityEngine;

public enum WeaponType
{
    None,
    PlayerBullet,
    PlayerMissile,
    PlayerBomb,
}

public abstract class BaseWeapon
{
    public abstract string Name { get; }
    public abstract WeaponType Type { get; }

    //Instantiate the weapon from the factory
    public abstract void Instantiate(PlayerController controller);
}
