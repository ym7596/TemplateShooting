
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : SingleTon<MySceneManager>
{
    public int currentIndex { get; private set; }
    public void LoadScene(int sceneIndex)
    {
        currentIndex = sceneIndex;

        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(currentIndex);

        yield return new WaitUntil(() => asyncOperation.isDone);
    }

}
