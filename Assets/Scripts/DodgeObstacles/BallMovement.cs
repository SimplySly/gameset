using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballMovementSpeed = 0.1f;

    public Transform leftPoint;
    public Transform rightPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPoint.position, ballMovementSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPoint.position, ballMovementSpeed);
        }
    }
}
