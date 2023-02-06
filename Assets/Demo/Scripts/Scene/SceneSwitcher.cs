using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public sceneName _sceneName = sceneName.Lobby;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("asd");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("asd");
            MySceneManager.instance.LoadScene((int)_sceneName);
        }
    }
}
