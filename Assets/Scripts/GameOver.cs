using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] SceneFader sceneFader;
    private readonly string menuSceneName = "MainMenu";

    public void Retry()
    {
        WaveSpawner.EnemiesAlive = 0;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        WaveSpawner.EnemiesAlive = 0;
        sceneFader.FadeTo(menuSceneName);
    }
}
