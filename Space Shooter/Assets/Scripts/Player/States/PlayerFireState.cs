using System;
using UnityEngine;

public class PlayerFireState : BaseState
{
    private PlayerController playerController;
    private BaseWeapon playerBullet;
    private float fireRate;
    private float previousFireTime;

    public PlayerFireState(PlayerController controller) : base(controller.gameObject)
    {
        playerController = controller;
        playerBullet = playerController.WeaponFactory.GetWeapon(WeaponType.PlayerBullet);
        fireRate = playerController.PlayerProperties.bulletData.fireRate;
        previousFireTime = 0;
    }



    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override Type OnStateUpdate()
    {
        if(Time.time > previousFireTime + fireRate)
        {
            playerBullet?.Instantiate(playerController);
            previousFireTime = Time.time;
        }
        
        return null;
    }

    public override void OnStateDestroy()
    {

    }
}
