using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstPersonMovementSO", menuName = "Movement/FirstPersonMovementSO")]
public class FPSMovement : Movement
{
    public override void Enable(Transform target = null, CharacterController characterController = null, Animator animator = null)
    {
        base.Enable(target, characterController, animator);
    }
    public override void Disable()
    {
       
    }

    public override void MovementFixedUpdate(Transform camArm,bool isGrounded, InputPlayer inputData)
    {
        bool isMove = ( inputData != null ) ? inputData.IsMove : false;
        Vector3 moveDir = new Vector3();
        if (isGrounded)
        {
            Vector3 lookForward = new Vector3(camArm.forward.x, 0f, camArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(camArm.right.x, 0f, camArm.right.z).normalized;
            moveDir = lookForward * inputData.moveInput.y + lookRight * inputData.moveInput.x;

            _targetTransform.forward = lookForward;
            _characterController.Move(moveDir * Time.deltaTime * speed);
        }
        var velo = moveDir * speed + Vector3.up * currentVelocityY;
        currentVelocityY += Time.deltaTime * Physics.gravity.y;

        _characterController.Move(velo * Time.deltaTime);

        if (_characterController.isGrounded)
            currentVelocityY = 0;

        _animator.SetBool("isMove", isMove);
    }

    public override void OnFire(string action,State state, Transform spawnPoint)
    {
        if (action == "Fire1" && state == State.Ready)
        {
            _animator.SetTrigger(action);

        }
            
    }

    public override void RotateFixedUpdate(Transform camArm, Camera cam, InputPlayer inputData)
    {
        Vector3 camAngle = camArm.rotation.eulerAngles;

        float x = camAngle.x - inputData.mouseInput.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        camArm.rotation = Quaternion.Euler(x, camAngle.y + inputData.mouseInput.x, camAngle.z);

    }
}
