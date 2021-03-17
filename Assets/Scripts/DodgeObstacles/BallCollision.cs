using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{
    public GameObject panelUI;
    public GameObject loseText;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.parent != null)
        {
            if (collision.collider.transform.parent.name == "Obstacles")
            {
                Debug.Log("Game Lost");
                transform.gameObject.SetActive(false);
                Destroy(transform.gameObject);

                panelUI.SetActive(true);
                loseText.SetActive(true);
            }
        }
    }
}
