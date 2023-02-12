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
    private TextMeshProUGUI _startCnt;
    [SerializeField]
    private TextMeshProUGUI _nickNametxt;
    [SerializeField]
    private TextMeshProUGUI _resulttxt;
    [SerializeField]
    private TextMeshProUGUI _remainTimetxt;
    [SerializeField]
    private SpawnManager _spawnManager;

    [SerializeField]
    private int _countDown = 3;

    [SerializeField]
    private Image _hitEffectPanel;

   
    public Slider _playerSlider;

    private int _timeCount = 30;

    public GameObject _startPanel;

    public GameObject _gamePanel;

    public GameObject _resultPanel;


    public GameObject _reloadPanel;

    public Slider _reloadSlider;
    public Toggle _onSwitchViewtgl;
   

    private float _sliderValue = 0;

    public string resultTxt
    {
        get { return _resulttxt.text; }
        set { _resulttxt.text = value; }
    }
    public int countDown
    {
        get { return _countDown; }
        set
        {
            _countDown = value;
            _startCnt.text = _countDown.ToString();
        }
    }

    public int timeCountDown
    {
        get { return _timeCount; }
        set
        {
            _timeCount = value;
            _remainTimetxt.text = string.Format("Time : {0}", _timeCount);
        }
    }

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
            _startPanel.SetActive(true);
            _resultPanel.SetActive(false);
            StartCoroutine(CountDownCo());
        }
        else
        {
            Debug.Log("GamaManager is not instance");
        }
           
    }

    public void PlayerHitEffect()
    {
        StartCoroutine(ColorAlhpaChangeCo(_hitEffectPanel.color));
    }

    private IEnumerator ColorAlhpaChangeCo(Color color)
    {
        for (float i = 0;i< 45; i+=1)
        {
            yield return new WaitForSeconds(0.02f);
            color.a = i /255;
            _hitEffectPanel.color = color;
        }
       // yield return new WaitUntil(() => color.a >= 90);
        for(float i = 45; i != 0; i-=1)
        {
            yield return new WaitForSeconds(0.02f);
            color.a = i / 255;
            _hitEffectPanel.color = color;
        }
    }

    private IEnumerator TimeCountCo()
    {
        yield return new WaitForSeconds(1.0f);
        if (timeCountDown != 0)
        {
            timeCountDown -= 1;
            StartCoroutine(TimeCountCo());
        }
        else
        {
            GameManager.instance.GameSet(Winner.Boss);
        }
    }
    private IEnumerator CountDownCo()
    {
        
        yield return new WaitForSeconds(1.0f);
        if(countDown != 0)
        {
            countDown -= 1;
            StartCoroutine(CountDownCo());
        }
        else
        {
            _startPanel.SetActive(false);
            _gamePanel.SetActive(true);
            _spawnManager.SpawnPlayer();
            StartCoroutine(TimeCountCo());
        }
        
    }

    public void GameOverResult(string winnertxt)
    {
        countDown = 5;
        _resultPanel.SetActive(true);
        resultTxt = winnertxt;
        StopAllCoroutines();
        StartCoroutine(GameResultCo());
    }
    private IEnumerator GameResultCo()
    {
        yield return new WaitForSeconds(1.0f);
        if(countDown != 0)
        {
            countDown -= 1;
            StartCoroutine(GameResultCo());
        }
        else
        {
            MySceneManager.instance.LoadScene((int) sceneName.Lobby);
            GameManager.instance.Init();
        }
    }


}
