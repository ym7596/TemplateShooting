using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;

    [SerializeField]
    private InputPlayer _playerInput;

    [SerializeField]
    private Camera _tpsCam;

    [SerializeField]
    private TPSMovement _tpsMovement;

    // Start is called before the first frame update
    void Start()
    {
        _tpsMovement.Enable(gameObject.transform, _controller);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _tpsMovement.MovementFixedUpdate(_controller.isGrounded, _playerInput.moveInput);
    }
}
