using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<Vector2> MovementAction;
   
    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector3(horizontal, vertical);

        //If move input fire an event to move player
        if(movement.magnitude > 0)
        {
            MovementAction?.Invoke(movement);
        }
    }
}
