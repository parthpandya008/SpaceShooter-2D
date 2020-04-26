using System;
using UnityEngine;

public class PlayerDeathState : BaseState
{
    private PlayerController playerController;

    public PlayerDeathState(PlayerController controller) : base(controller.gameObject)
    {
        playerController = controller;
    }



    public override void OnStateEnter()
    {
        playerController.DisablePlayer();
        GameManager.Instance.EndGame();
        GameObject explossion = ObjectPooler.Instance.SpwanFrompool("PlayerExplossion");
        explossion.transform.position = playerController.transform.position;        
    }

    public override void OnStateExit()
    {

    }

    public override Type OnStateUpdate()
    {
        return null;
    }

    public override void OnStateDestroy()
    {

    }

    public override Type OnStateFixedUpdate()
    {
        return null;
    }

    private void DisablePlayer()
    {
        
    }
}
