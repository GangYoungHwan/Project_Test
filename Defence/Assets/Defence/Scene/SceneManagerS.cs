using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerS : MonoBehaviour
{
    static public SceneManagerS instance;
    void Start()
    {
        instance = this;
    }
    public void TitleScene()
    {
        SceneManager.LoadScene("Title");
    }
    public void MainScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
