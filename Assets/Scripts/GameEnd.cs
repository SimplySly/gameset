using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private int menuSceneIndex = 0;
    public void GameEndProcedure()
    {

        SceneManager.LoadScene(menuSceneIndex);
    }
}
