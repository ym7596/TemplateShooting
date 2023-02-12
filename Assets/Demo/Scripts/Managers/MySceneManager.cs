
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MySceneManager : SingleTon<MySceneManager>
{
    public int currentIndex { get; private set; }

    public sceneLoadStatus sceneStatus = sceneLoadStatus.None;

    public Action progressEvent = null;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public float ProgressNum
    {
        get; private set;
    }

    public void LoadScene(int sceneIndex)
    {
        sceneStatus = sceneLoadStatus.Loading;
        currentIndex = sceneIndex;

        StartCoroutine(LoadScene());
    }

    public void LoadSceneAsync(int sceneIndex)
    {
        sceneStatus = sceneLoadStatus.Loading;
        currentIndex = sceneIndex;

        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(currentIndex);

        while (asyncOperation.isDone)
        {
            ProgressNum = asyncOperation.progress;
            Debug.Log(asyncOperation.progress);
            yield return new WaitForSeconds(10f);
           
        }
        sceneStatus = sceneLoadStatus.Complete;
    }
    private IEnumerator LoadScene()
    {
        yield return null;

       // AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(currentIndex);
        SceneManager.LoadScene(currentIndex);
       // yield return new WaitUntil(() => asyncOperation.isDone);
        sceneStatus = sceneLoadStatus.Complete;
    }

}
