using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperLose : MonoBehaviour
{
    public GameObject panelUI;
    public GameObject loseText;
    public GameObject jumperObject;
    public void JumperLoseProcedure()
    {
        jumperObject.SetActive(false);
        Destroy(jumperObject);

        panelUI.SetActive(true);
        loseText.SetActive(true);
    }
}
