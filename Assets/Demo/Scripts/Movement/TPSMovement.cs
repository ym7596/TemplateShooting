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

    public override void MovementFixedUpdate(Transform camArm,bool isGrounded, Vector2 moveInput)
    {
        Vector3 moveDir = new Vector3();
        if (isGrounded)
        {
            Vector3 lookForward = new Vector3(camArm.forward.x, 0f, camArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(camArm.right.x, 0f, camArm.right.z).normalized;
            moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            _targetTransform.forward = lookForward;
            _characterController.Move(moveDir * Time.deltaTime * speed);
        }
        var velo = moveDir * speed + Vector3.up * currentVelocityY; 
        currentVelocityY += Time.deltaTime * Physics.gravity.y;

        _characterController.Move(velo * Time.deltaTime);

        if (_characterController.isGrounded)
            currentVelocityY = 0;
    }

    public override void OnAction(string action,bool isGround)
    {
        if (action == "Jump" && isGround == true)
            currentVelocityY = jumpVelocity;
    }

    public override void RotateFixedUpdate(Transform camArm,Camera cam, Vector2 mouseInput)
    {
        Vector3 camAngle = camArm.rotation.eulerAngles;

        float x = camAngle.x - mouseInput.y;

        if(x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        camArm.rotation = Quaternion.Euler(x, camAngle.y + mouseInput.x, camAngle.z);
    }
}
