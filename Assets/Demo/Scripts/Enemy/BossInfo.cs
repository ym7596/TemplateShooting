using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossInfo : MonoBehaviour, Observer
{
    [SerializeField]
    private Slider _bossHPbar = null;

    private HealthSub _subject = null;

    private float _maxBossHP = 1000;
    private float _currentBossHP = 0;
    [SerializeField]
    private BossState _bossState;
    public float maxbossHP
    {
        get { return _maxBossHP; }
        set { _maxBossHP = value; }
    }

    public float currentHP
    {
        get { return _currentBossHP; }
        set { _currentBossHP = value;
            _bossHPbar.value = _currentBossHP / maxbossHP;
        }
    }

    private void Start()
    {
        currentHP += maxbossHP;
    }

    public void Init(HealthSub _subject)
    {
        this._subject = _subject;
    }

    public void ObserverUpdate(float _myHP, float _enemyHP)
    {
        _bossHPbar.value = _enemyHP;
    }

    private void OnTriggerEnter(Collider col)
    {
        int colLayer = col.gameObject.layer;
        if (colLayer == LayerMask.NameToLayer("Bullet"))
        {
            int damage = col.gameObject.GetComponent<Bullet>().bulletDamage;
            currentHP -= damage;
            HPStats.instance.SetChangeStat();
            if(currentHP <= 0)
            {
                _bossState.state = bossState.Die;
            }
        }
    }
}
