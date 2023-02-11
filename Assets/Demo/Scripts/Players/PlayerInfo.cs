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
    }

    private void Start()
    {
        NickName = GameManager.instance.nickName;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
