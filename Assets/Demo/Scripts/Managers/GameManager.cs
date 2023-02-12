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

    public Winner winner = Winner.None;
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

    public void Init()
    {
        winner = Winner.None;
        isGameOver = false;
        _userInfo = new UserInfo();
    }

    public void GameSet(Winner winner)
    {
        if(isGameOver != true)
        {
            isGameOver = true;
            Debug.Log("GameOVer");
            switch (winner)
            {
                case Winner.Player:
                    {
                        winner = Winner.Player;
                        if (InGameUI.instance)
                        {
                            InGameUI.instance.GameOverResult("YOU WIN!");
                        }
                    }
                    break;
                case Winner.Boss:
                    {
                        winner = Winner.Boss;
                        if (InGameUI.instance)
                        {
                            InGameUI.instance.GameOverResult("YOU LOSE!");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
       
    }

}
