using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPStats : SingleTon<HPStats>
{
    [SerializeField]
    private HealthSub _healthSub = null;

    public PlayerInfo playerInfo = null;
    public BossInfo bossInfo = null;

    private float _maxPlayerHP = 1;
    private float _maxBossHP = 1;

    private float _currentPlayerHP = 0f;
    private float _currentBossHP = 0f;
    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        
    }

    

    public void SetInitHP()
    {
        playerInfo.Init(_healthSub);
        bossInfo.Init(_healthSub);



        _currentPlayerHP = _maxPlayerHP;
   

        _healthSub.RegisterObserver(playerInfo);
        _healthSub.RegisterObserver(bossInfo);

        _healthSub.ChangeHP(playerInfo.CurrentPlayerHP / playerInfo.playerMaxHP, bossInfo.currentHP / bossInfo.maxbossHP);
    }

    public void SetChangeStat()
    {
        _healthSub.ChangeHP(playerInfo.CurrentPlayerHP / playerInfo.playerMaxHP, bossInfo.currentHP / bossInfo.maxbossHP);
        _currentPlayerHP = playerInfo.CurrentPlayerHP;
        _currentBossHP = bossInfo.currentHP;

        if(_currentBossHP <= 0f)
        {
            GameManager.instance.GameSet(Winner.Player);
        }
        else if(_currentPlayerHP <= 0f)
        {
            GameManager.instance.GameSet(Winner.Boss);
        }
    }
}
