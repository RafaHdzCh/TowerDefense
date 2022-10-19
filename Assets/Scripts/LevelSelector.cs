using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] SceneFader fader;
    [SerializeField] Button[] levelButtons; 
    private readonly string mainMenuScene = "MainMenu";
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt(nameof(levelReached),1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void SelectLevel(string levelName)
    {
        WaveSpawner.EnemiesAlive = 0;
        fader.FadeTo(levelName);
    }

    public void BackToMainMenu()
    {
        fader.FadeTo(mainMenuScene);
    }
}
