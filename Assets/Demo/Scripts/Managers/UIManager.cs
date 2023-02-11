using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private InputField _nickName;

    [SerializeField]
    private GameObject _errPopup;

    public void OnStartButton()
    {
        if (NickNameCheck(_nickName) == false)
        {
            _errPopup.SetActive(true);
        }
        else
        {
            GameManager.instance.nickName = _nickName.text;
            MySceneManager.instance.LoadScene((int)sceneName.Loading);
        }

    }
  
    private bool NickNameCheck(InputField _nick)
    {
        int characterLen = _nick.text.Length;
        
        if (characterLen < 3)
            return false;
        else
            return true;
    }
    
}
