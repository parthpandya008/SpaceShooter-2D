using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BaseState
{
    private PlayerController playerController;
    private bool isMoved;

    public PlayerIdleState(PlayerController controller) : base(controller.gameObject)
    {
        playerController = controller;
        playerController.InputController.MovementAction += OnMove;
    }

    private void OnMove(Vector2 obj)
    {
        isMoved = true;
    }

    public override void OnStateEnter()
    {
        isMoved = false;
    }

    public override void OnStateExit()
    {
        isMoved = false;
    }

    public override Type OnStateUpdate()
    {
        if(isMoved)
        {
            return typeof(PlayerMoveState);
        }
        return null;
    }

    public override Type OnStateFixedUpdate()
    {
        return null;
    }

    public override void OnStateDestroy()
    {
        playerController.InputController.MovementAction -= OnMove;
    }
}
