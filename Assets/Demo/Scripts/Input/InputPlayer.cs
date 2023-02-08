using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public string moveHorizontalAxis = "Horizontal";
    public string moveVerticalAxis = "Vertical";

    public string fireBtnName = "Fire1";
    public string jumpBtnName = "Jump";
    public string reloadButtonName = "Reload";

    public Vector2 moveInput { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }
    public bool jump { get; private set; }


    private void Update()
    {
        if (GameManager.instance != null
                && GameManager.instance.isGameOver == true)
        {
            moveInput = Vector2.zero;
            fire = false;
            reload = false;
            jump = false;

            return;
        }

        moveInput = new Vector2(Input.GetAxis(moveHorizontalAxis),
            Input.GetAxis(moveVerticalAxis));

        if (moveInput.sqrMagnitude > 1) moveInput = moveInput.normalized;

        jump = Input.GetButtonDown(jumpBtnName);
        fire = Input.GetButton(fireBtnName);
        reload = Input.GetButtonDown(reloadButtonName);
    }
}
