using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] SceneFader sceneFader;
    private readonly string menuSceneName = "MainMenu";

    public string nextLevel = "Level2";
    public int levelUnlock = 2;

    public void NextLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
