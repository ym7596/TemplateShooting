using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInfo : MonoBehaviour, Observer
{
    [SerializeField]
    private Slider _hpSlider;

    [SerializeField]
    private TextMeshProUGUI _nickName;

    private HealthSub _subject = null;

    private float _playerHP = 500;
    private float _currentPlayerHP = 0f;
    public float playerMaxHP { 
        get 
        {
            return _playerHP;
        }
        set 
        {
            _playerHP = value;
        } 
    }

    public float CurrentPlayerHP
    {
        get
        {
            return _currentPlayerHP;
        }
        set
        {
            _currentPlayerHP = value;
            _hpSlider.value = _currentPlayerHP / playerMaxHP;
            InGameUI.instance._playerSlider.value = _currentPlayerHP / playerMaxHP;
        }
    }
    public string NickName
    {
        get { return _nickName.text; }
        set { _nickName.text = value; }
    }

    

    public void Init(HealthSub _subject)
    {
        this._subject = _subject;
    }
    
    public void ObserverUpdate(float _myHP, float _enemyHP)
    {
        _hpSlider.value = _myHP;
        InGameUI.instance._playerSlider.value = _myHP;
    }

    private void Start()
    {
        CurrentPlayerHP += playerMaxHP;
        StartCoroutine(SetNick());
    }

    IEnumerator SetNick()
    {
        yield return new WaitUntil(() => GameManager.instance);
        NickName = GameManager.instance.nickName;
    }


    private void OnTriggerEnter(Collider col)
    {
        int colLayer = col.gameObject.layer;
        if (colLayer == LayerMask.NameToLayer("BossBullet"))
        {
            int damage = col.gameObject.GetComponent<Bullet>().bulletDamage;
            CurrentPlayerHP -= damage;
            HPStats.instance.SetChangeStat();
            InGameUI.instance.PlayerHitEffect();
        }
    }

}
