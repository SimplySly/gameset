using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumperWin : MonoBehaviour
{
    public GameObject panelUI;
    public GameObject winText;
    public GameObject jumperObject;

    private int jumperBaseIndex = 2;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "FinishArea")
        {
            if (PlayerPrefs.HasKey("JumperCurrentLevel"))
            {
                PlayerPrefs.SetInt("JumperCurrentLevel", SceneManager.GetActiveScene().buildIndex - jumperBaseIndex + 1);
            }
            else
            {
#if DEBUG
                Debug.Log("Failed to mark level as passed");
#endif
            }


            jumperObject.SetActive(false);
            Destroy(jumperObject);

            panelUI.SetActive(true);
            winText.SetActive(true);
        }
    }
}
