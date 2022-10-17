using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartProgress : MonoBehaviour
{
    [SerializeField] SceneFader sceneFader;
    public void DeletePlayerProgress()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        PlayerPrefs.DeleteAll();
    }
}
