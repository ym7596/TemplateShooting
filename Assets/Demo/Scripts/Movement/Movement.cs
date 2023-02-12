using UnityEngine;


public abstract class Movement : ScriptableObject
{
    protected CharacterController _characterController;
    protected Animator _animator;
    protected Transform _targetTransform;

    public float gravity = 20;



    public float speed = 6f;


    public float speedSmoothTime = 0.1f;
    public float turnSmoothTime = 0.1f;


    public float currentVelocityY;
    public float currentSpeed =>
      new Vector2(_characterController.velocity.x, _characterController.velocity.z).magnitude;



    public virtual void Enable(Transform target = null, CharacterController characterController = null
        ,Animator animator = null)
    {
        _targetTransform = target;
        _characterController = characterController;
        _animator = animator;
    }

    public abstract void Disable();

    public abstract void OnFire(string action,State state, Transform spawnPoint);

    public abstract void MovementFixedUpdate(Transform camArm,bool isGrounded, InputPlayer inputData);

    public abstract void RotateFixedUpdate(Transform _target, Camera cam, InputPlayer inputData);

   
}
