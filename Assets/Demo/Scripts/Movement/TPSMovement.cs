using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThirdPersonMovementSO", menuName = "Movement/ThirdPersonMovementSO")]
public class TPSMovement : Movement
{

    public override void Enable(Transform target = null, CharacterController characterController = null)
    {
        base.Enable(target, characterController);

    }
    public override void Disable()
    {
        
    }

    public override void MovementFixedUpdate(bool isGrounded, Vector2 moveInput)
    {
        var targetSpeed = speed * moveInput.magnitude;
        var moveDirection = Vector3.Normalize(_targetTransform.transform.forward * moveInput.y + _targetTransform.right * moveInput.x);

        var smoothTime = _characterController.isGrounded ? speedSmoothTime : speedSmoothTime / airControlPercent;

        targetSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, smoothTime);
        currentVelocityY += Time.deltaTime * Physics.gravity.y;

        var velocity = moveDirection * targetSpeed + Vector3.up * currentVelocityY;

        _characterController.Move(velocity * Time.deltaTime);

        if (_characterController.isGrounded) currentVelocityY = 0;
    }

    public override void OnAction(string action)
    {
        
    }

    public override void RotateFixedUpdate(Camera cam)
    {
        
    }
}
