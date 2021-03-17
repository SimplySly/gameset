using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonProcedures : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject dodgeObstaclesLevelPanel;
    public GameObject jumperLevelPanel;

    public GameObject[] dodgeObstacleLevelButtons;
    public GameObject[] jumperLevelButtons;

    private int dodgeObstacleBaseNumber = 0;
    private int jumperBaseNumber = 2;

    public void LoadDodgeObstacleLevel(int level)
    {
        SceneManager.LoadScene(dodgeObstacleBaseNumber + level);
    }

    public void LoadJumperLevel(int level)
    {
        SceneManager.LoadScene(jumperBaseNumber + level);
    }

    public void ShowDodgeObstaclesLevels()
    {
        DisableAllPanels();
        dodgeObstaclesLevelPanel.SetActive(true);

        int currentLevel;
        if (PlayerPrefs.HasKey("DodgeObstacleCurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("DodgeObstacleCurrentLevel");
        }
        else
        {
            currentLevel = 1;
            PlayerPrefs.SetInt("DodgeObstacleCurrentLevel", currentLevel);
        }

        DisableLevelButtons(dodgeObstacleLevelButtons, currentLevel);
    }

    public void ShowJumperLevels()
    {
        DisableAllPanels();
        jumperLevelPanel.SetActive(true);

        int currentLevel;
        if (PlayerPrefs.HasKey("JumperCurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("JumperCurrentLevel");
        }
        else
        {
            currentLevel = 1;
            PlayerPrefs.SetInt("JumperCurrentLevel", currentLevel);
        }

        DisableLevelButtons(jumperLevelButtons, currentLevel);
    }

    public void ShowMainMenu()
    {
        DisableAllPanels();
        menuPanel.SetActive(true);
    }


    public void ExitGame()
    {
#if DEBUG
        EditorApplication.isPlaying = false;
#endif
        Application.Quit(0);

    }

    private void DisableAllPanels()
    {
        menuPanel.SetActive(false);
        dodgeObstaclesLevelPanel.SetActive(false);
        jumperLevelPanel.SetActive(false);
    }

    private void DisableLevelButtons(GameObject[] levelButtons, int level)
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < level)
            {
                levelButtons[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                levelButtons[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}
