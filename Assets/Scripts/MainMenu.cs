using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public readonly string levelScene = "MainScene";

    public void Play()
    {
        SceneManager.LoadScene(levelScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
