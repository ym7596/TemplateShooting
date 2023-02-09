using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstPersonMovementSO", menuName = "Movement/FirstPersonMovementSO")]
public class FPSMovement : Movement
{
    public override void Disable()
    {
        throw new System.NotImplementedException();
    }

    public override void MovementFixedUpdate(bool isGrounded, Vector2 moveInput)
    {
        throw new System.NotImplementedException();
    }

    public override void OnAction(string action)
    {
        throw new System.NotImplementedException();
    }

    public override void RotateFixedUpdate(Camera cam)
    {
        throw new System.NotImplementedException();
    }
}
