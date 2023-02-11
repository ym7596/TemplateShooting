using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InGameUI : SingleTon<InGameUI>
{
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

    protected override void Awake()
    {
        base.Awake();
    }

    [SerializeField]
    private TextMeshProUGUI _bulletCnt;
   
    public GameObject _startPanel;

    public GameObject _gamePanel;

    public GameObject _resultPanel;


    public GameObject _reloadPanel;

    public Slider _reloadSlider;


}
