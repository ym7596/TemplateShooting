using UnityEngine;
using UnityEngine.UI;

public class ProgressBarControl : MonoBehaviour
{
    [SerializeField]
    private Slider _progressBar;




    private float _currentLoading = 0f;
    public float loadProgress
    {
        get
        {
            return _currentLoading;
        }
        set
        {
            _currentLoading = value;
            _progressBar.value = value;
        }
    }

    private void Update()
    {
        if (MySceneManager.instance == null)
            return;

        loadProgress = MySceneManager.instance.ProgressNum;
    }
}
