using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [HideInInspector] public static bool gameEnded;

    private void Start()
    {
        gameEnded = false;
    }

    void Update()
    {
        if (gameEnded) return;

        if(Input.GetKeyDown(KeyCode.E))
        {
            EndGame();
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
    }
}
