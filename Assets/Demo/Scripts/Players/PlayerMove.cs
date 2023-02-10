using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private currentView _curView = currentView.TPS;
    public currentView CurView
    {
        get { return _curView; }
        set { _curView = value; }
    }


    [SerializeField]
    private CharacterController _controller;

    [SerializeField]
    private InputPlayer _playerInput;
    [SerializeField]
    private Transform _playerBody;
    [SerializeField]
    private Transform _tpscamArm;

    [SerializeField]
    private Camera _tpsCam;

    [SerializeField]
    private TPSMovement _tpsMovement;
    [SerializeField]
    private FPSMovement _fpsMovement;

    
    // Start is called before the first frame update
    void Start()
    {
        _tpsMovement.Enable(_playerBody, _controller);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerCamView(CurView);
    }


    private void PlayerCamView(currentView _view)
    {
        switch (_view)
        {
            case currentView.TPS:
                {
                    TPSMove();
                }
                break;
            case currentView.FPS:
                {
                    FPSMove();
                }
                break;
        }
    }
    private void FPSMove()
    {

    }

    private void TPSMove()
    {
        _tpsMovement.RotateFixedUpdate(_tpscamArm, _tpsCam, _playerInput.mouseInput);
        _tpsMovement.MovementFixedUpdate(_tpscamArm, _controller.isGrounded, _playerInput.moveInput);

        if (_playerInput.jump)
            _tpsMovement.OnAction(_playerInput.jumpBtnName, _controller.isGrounded);
    }
}
