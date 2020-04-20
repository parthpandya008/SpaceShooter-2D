using UnityEngine;
using System;

[Serializable]
public class PlayerBullet : BaseWeapon
{
    public override string Name => "PlayerBullet";

    public override WeaponType Type => WeaponType.PlayerBullet;

    public override void Instantiate(PlayerController controller)
    {
        //Instantiate the bullet
        Debug.Log("Player Bulllet");
        GameObject bullet = ObjectPooler.Instance.SpwanFrompool("PlayerBullet");
        bullet.transform.position = controller.BulletSpwanPoint.position;
        PlayerBulletObject bulletObject = bullet.GetComponent<PlayerBulletObject>();
        bulletObject.setBulletSpeed(controller.PlayerProperties.bulletData.speed);
    }
}