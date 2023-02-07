using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public sceneName _sceneName = sceneName.Lobby;

    private void Start()
    {
        switch (MySceneManager.instance.currentIndex)
        {
            case (int)sceneName.Loading:
                {
                    Debug.Log("Loading");
                    MySceneManager.instance.LoadSceneAsync((int) _sceneName);
                }
                break;

        }
    }
    void Update()
    {
        if (MySceneManager.instance == null ||
            _sceneName != sceneName.Lobby)
            return;

        if (Input.anyKeyDown)
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        if (MySceneManager.instance.sceneStatus == sceneLoadStatus.Loading)
            return;

        MySceneManager.instance.LoadScene((int) _sceneName);
    }
}
