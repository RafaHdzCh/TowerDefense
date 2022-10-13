using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private readonly string levelScene = "MainScene";
    [SerializeField] SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
