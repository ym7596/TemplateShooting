using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    public string nickName = "test";

}
public class GameManager : SingleTon<GameManager>
{
    public bool isGameOver { get; private set; }

    UserInfo _userInfo = new UserInfo();

    public string nickName
    {
        get { return _userInfo.nickName; }
        set { _userInfo.nickName = value; }
    }

    protected override void Awake()
    {
        _userInfo.nickName = "babo";
        base.Awake();
        DontDestroyOnLoad(gameObject);
        
    }

}
