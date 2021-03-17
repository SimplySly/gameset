using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMovement : MonoBehaviour
{
    public Rigidbody jRigidBody;
    public JumperLose jLoseScript;
    public float jumpAmount = 400f;
    public float moveAmount = 20f;

    private Vector3 horizontalAxis = new Vector3(0, 0, 1);
    private Vector3 verticalAxis = new Vector3(0, 1, 0);
    private float jumpTreshold = 0.0005f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(jRigidBody.velocity);
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Math.Abs(Vector3.Dot(jRigidBody.velocity, verticalAxis)) < jumpTreshold)
        {
            jRigidBody.AddForce(verticalAxis * jumpAmount);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            jRigidBody.AddForce(-horizontalAxis * moveAmount);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            jRigidBody.AddForce(horizontalAxis * moveAmount);
        }

        if (transform.position.y < -10)
        {
            jLoseScript.JumperLoseProcedure();
        }
    }
}
