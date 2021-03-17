using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJumper : MonoBehaviour
{
    public Transform jumper;
    public float interpolationSpeed = 2;

    private Vector3 offset = new Vector3(7, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = jumper.position + offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (jumper != null)
        {
            var targetPosition = jumper.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, interpolationSpeed * Time.deltaTime);
        }       
    }
}
