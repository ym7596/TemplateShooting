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

    public override void MovementFixedUpdate(Transform camArm,bool isGrounded, Vector2 moveInput)
    {
        throw new System.NotImplementedException();
    }

    public override void OnAction(string action,bool isGrounded)
    {
        throw new System.NotImplementedException();
    }

    public override void RotateFixedUpdate(Transform _target, Camera cam,Vector2 mouseInput)
    {
        throw new System.NotImplementedException();
    }
}
