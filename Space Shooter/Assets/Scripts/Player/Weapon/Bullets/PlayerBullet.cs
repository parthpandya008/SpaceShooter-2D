using UnityEngine;
using System;

public class PlayerBullet : BaseWeapon
{
    public override string Name => "PlayerBullet";

    public override WeaponType Type => WeaponType.PlayerBullet;

    /// <summary>
    /// Instantiate the Player Bullet
    /// </summary>
    /// <param name="controller"></param>
    public override void Instantiate(PlayerController controller)
    {
        //Instantiate the bullet
        
        GameObject bullet = ObjectPooler.Instance.SpwanFrompool("PlayerBullet");
        bullet.transform.position = controller.BulletSpwanPoint.position;
        bullet.transform.localEulerAngles = Vector2.zero;
        PlayerBulletObject bulletObject = bullet.GetComponent<PlayerBulletObject>();
        bulletObject.SetData(controller);
    }
}