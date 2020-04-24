using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveState : BaseState
{
    private PlayerController playerController;
    private Vector2 movement;
    private Rigidbody2D playerRigidbody;

    public PlayerMoveState(PlayerController controller) : base(controller.gameObject)
    {
        playerController = controller;
     
        playerController.InputController.MovementAction += OnMove;

        playerRigidbody = playerController.GetComponent<Rigidbody2D>();
    }

    private void OnMove(Vector2 obj)
    {
        movement = obj;
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override Type OnStateUpdate()
    {
        if (movement.magnitude > 0)
        {
            MovePlayer();
            movement = Vector2.zero;
        }
        else
        {
            return typeof(PlayerIdleState);
        }
        return null;
    }

    public override Type OnStateFixedUpdate()
    {
        return null;
    }

    private void MovePlayer()
    {
        Vector2 pos = playerRigidbody.position;
        pos.x += movement.x ;
        pos.y += movement.y;
        pos.x = Mathf.Clamp(pos.x, playerController.minMoveX, playerController.maxMoveX);
        pos.y = Mathf.Clamp(pos.y, playerController.minMoveY, playerController.maxMoveY);

        pos = Vector2.Lerp(playerRigidbody.position, pos, Time.deltaTime * playerController.PlayerProperties.moveSensitivity);
        playerRigidbody.MovePosition(pos);
        // playerTransform.position = Vector2.Lerp(playerTransform.position, pos, Time.deltaTime * playerController.PlayerProperties.moveSensitivity);
    }

    public override void OnStateDestroy()
    {
        playerController.InputController.MovementAction -= OnMove;
    }
}
