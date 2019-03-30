using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private float _autoLoadLevelDelayTime;

    private void Start()
    {
        _autoLoadLevelDelayTime = 2.8f;
        if (SceneManager.GetActiveScene().name == "Splash")
        {
            Invoke("GoNextLevel", _autoLoadLevelDelayTime);
        }
    }
    public void MyLevelsLoad(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void MyLevelsQuit()
    {
        Application.Quit();
    }
    public void GoNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
