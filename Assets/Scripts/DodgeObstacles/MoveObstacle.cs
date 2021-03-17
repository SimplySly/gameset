using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveObstacle : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;

    public float maxTravelDistance = 0.05f;
    private float maxDeleteDistance = 1f;

    public GameWin GameWinScript;

    private float tmp = 0;
    private float distance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetPlane = new Plane(point1.position, point2.position, point3.position);
        
        for (int i = 0; i < transform.childCount; i++)
        {
            var obstacle = transform.GetChild(i);
            var targetPoint = targetPlane.ClosestPointOnPlane(obstacle.position);

            if (i == 2)
            {
                if (distance < 1f)
                {
                    distance += -(Vector3.MoveTowards(obstacle.position, targetPoint, maxTravelDistance) - obstacle.position).x;

                    tmp += Time.deltaTime;
                }
                else
                {
                    Debug.Log(tmp);
                }
            }

            obstacle.position = Vector3.MoveTowards(obstacle.position, targetPoint, maxTravelDistance);
            if (Vector3.Distance(obstacle.position, targetPoint) < maxDeleteDistance)
            {
                obstacle.gameObject.SetActive(false);
                obstacle.parent = null;
                Destroy(obstacle.gameObject);
                i--;
            }            
        }

        if (transform.childCount <= 0)
        {
            GameWinScript.GameWinProcedure();
        }
    }
}
