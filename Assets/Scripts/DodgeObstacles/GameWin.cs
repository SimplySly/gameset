using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject panelUI;
    public GameObject winText;
    public GameObject ballObject;


    private int dodgeObstacleBaseIndex = 0;

    public void GameWinProcedure()
    {
        Debug.Log("Game Win");
        if (ballObject != null)
        {
            if (PlayerPrefs.HasKey("DodgeObstacleCurrentLevel"))
            {
                PlayerPrefs.SetInt("DodgeObstacleCurrentLevel", SceneManager.GetActiveScene().buildIndex - dodgeObstacleBaseIndex + 1);
            }
            else
            {
#if DEBUG
                Debug.Log("Failed to mark level as passed");
#endif
            }

            ballObject.SetActive(false);
            Destroy(ballObject);

            panelUI.SetActive(true);
            winText.SetActive(true);
        }
        


    }
}
