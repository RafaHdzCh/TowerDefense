using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] SceneFader sceneFader;
    private readonly string menuSceneName = "MainMenu";

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        if(pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        WaveSpawner.EnemiesAlive = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        Toggle();
        WaveSpawner.EnemiesAlive = 0;
        sceneFader.FadeTo(menuSceneName);
    }
}
