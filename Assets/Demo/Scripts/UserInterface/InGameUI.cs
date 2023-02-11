using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InGameUI : SingleTon<InGameUI>
{
    [SerializeField]
    private TextMeshProUGUI _bulletCnt;
    [SerializeField]
    private TextMeshProUGUI _nickNametxt;
    public GameObject _startPanel;

    public GameObject _gamePanel;

    public GameObject _resultPanel;


    public GameObject _reloadPanel;

    public Slider _reloadSlider;
    public Toggle _onSwitchViewtgl;
   

    private float _sliderValue = 0;
    
    public float sliderValue
    {
        get
        {
            return _sliderValue;
        }
        set
        {
            _sliderValue = value;
            _reloadSlider.value = _sliderValue;
        }
    }

    public string bulletCnt
    {
        get { return _bulletCnt.text; }
        set { _bulletCnt.text = value; }
    }

    public string userNick
    {
        get { return _nickNametxt.text; }
        set { _nickNametxt.text = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        
    }
    private void Start()
    {
        if (GameManager.instance)
        {
            userNick = GameManager.instance.nickName;
            Debug.Log(userNick);
        }
        else
        {
            Debug.Log("123");
        }
           
    }




}
