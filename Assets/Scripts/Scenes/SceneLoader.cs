using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int _currentScene;
    private int _maxScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        _maxScene = SceneManager.sceneCountInBuildSettings;
    }

    public void ReloadScene() => LoadScene(_currentScene);

    public void LoadNextScene()
    {
        if (_currentScene + 1 < _maxScene)
            LoadScene(_currentScene + 1);
        else ReloadScene();
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
