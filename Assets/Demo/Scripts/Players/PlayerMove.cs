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
    private Animator _anim;

    [SerializeField]
    private InputPlayer _playerInput;
    [SerializeField]
    private Transform _playerBody;
    [SerializeField]
    private Transform _tpscamArm;

    [SerializeField]
    private Camera _tpsCam;
    [SerializeField]
    private Camera _fpsCam;

    [SerializeField]
    private Gun _gun;
    [SerializeField]
    private Transform _bulletSpawnPoint;
    [SerializeField]
    private TPSMovement _tpsMovement;
    [SerializeField]
    private FPSMovement _fpsMovement;

    
    // Start is called before the first frame update
    void Start()
    {
        InGameUI.instance._onSwitchViewtgl.onValueChanged.AddListener
            (delegate { OnSwitchBtn(InGameUI.instance._onSwitchViewtgl.isOn); });
        SwitchViewType(_curView);
    }

    private void Update()
    {
        OnReload(_playerInput.reload);
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        PlayerCamView(CurView);
    }

    public void OnSwitchBtn(bool isFPS)
    {
        if (isFPS)
        {
            CurView = currentView.FPS;
        }
        else
        {
            CurView = currentView.TPS;
        }
        SwitchViewType(CurView);
    }

    private void SwitchViewType(currentView cView)
    {
        switch (cView)
        {
            case currentView.FPS:
                {
                    _fpsMovement.Enable(_playerBody, _controller, _anim);
                    _tpsCam.gameObject.SetActive(false);
                    _fpsCam.gameObject.SetActive(true);
                }
                break;
            case currentView.TPS:
                {
                    _tpsMovement.Enable(_playerBody, _controller, _anim);
                    _fpsCam.gameObject.SetActive(false);
                    _tpsCam.gameObject.SetActive(true);
                }
                break;
        }
    }

    private void OnReload(bool onReloadBtn)
    {
        if (onReloadBtn)
        {
            _gun.Reload();
        }
    }
    private void PlayerCamView(currentView _view)
    {
        switch (_view)
        {
            case currentView.TPS:
                {
                    _fpsCam.gameObject.SetActive(false);
                    _tpsCam.gameObject.SetActive(true);
                    TPSMove();
                }
                break;
            case currentView.FPS:
                {
                    _tpsCam.gameObject.SetActive(false);
                    _fpsCam.gameObject.SetActive(true);
                    FPSMove();
                }
                break;
        }
    }
    private void FPSMove()
    {                                                  
        _fpsMovement.RotateFixedUpdate(_tpscamArm, _tpsCam, _playerInput);
        _fpsMovement.MovementFixedUpdate(_tpscamArm, _controller.isGrounded, _playerInput);

        if (_playerInput.fire)
        {
            _gun.Fire(_bulletSpawnPoint);
            _fpsMovement.OnFire(_playerInput.fireBtnName, _gun.state, _bulletSpawnPoint);
        }
        else
            _anim.SetBool(_playerInput.fireBtnName, false);
            
    }

    private void TPSMove()
    {
        _tpsMovement.RotateFixedUpdate(_tpscamArm, _tpsCam, _playerInput);
        _tpsMovement.MovementFixedUpdate(_tpscamArm, _controller.isGrounded, _playerInput);

        if (_playerInput.fire)
        {
            _gun.Fire(_bulletSpawnPoint);
            _tpsMovement.OnFire(_playerInput.fireBtnName, _gun.state, _bulletSpawnPoint);
        }
        else
            _anim.SetBool(_playerInput.fireBtnName, false);

    }
}
