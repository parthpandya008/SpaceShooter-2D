using System;

public class PlayerDeathState : BaseState
{
    private PlayerController playerController;

    public PlayerDeathState(PlayerController controller) : base(controller.gameObject)
    {
        playerController = controller;
    }



    public override void OnStateEnter()
    {

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
}
