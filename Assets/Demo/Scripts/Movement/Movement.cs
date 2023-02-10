using UnityEngine;


public abstract class Movement : ScriptableObject
{
    protected CharacterController _characterController;

    protected Transform _targetTransform;

    public float gravity = 20;
    [Range(0.01f, 1f)]
    public float airControlPercent;


    public float speed = 6f;
    public float jumpVelocity = 20f;

    public float speedSmoothTime = 0.1f;
    public float turnSmoothTime = 0.1f;


    public float currentVelocityY;
    public float currentSpeed =>
      new Vector2(_characterController.velocity.x, _characterController.velocity.z).magnitude;



    public virtual void Enable(Transform target = null, CharacterController characterController = null)
    {
        _targetTransform = target;
        _characterController = characterController;
    }

    public abstract void Disable();

    public abstract void OnAction(string action,bool isGrounded);

    public abstract void MovementFixedUpdate(Transform camArm,bool isGrounded, Vector2 moveInput);

    public abstract void RotateFixedUpdate(Transform _target, Camera cam, Vector2 mouseInput);

   
}
