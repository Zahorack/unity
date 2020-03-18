using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContinously : MonoBehaviour
{

    public bool direction = true;
    public float speed = 0;
    public Vector3 axes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 6.0 * speed * Time.deltaTime, 0);

        transform.Rotate(new Vector3(0, 0, 1), direction ? Time.deltaTime* speed : -Time.deltaTime * speed);

        //transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);


       // transform.RotateAround(customPivot.position, axes, speed* Time.deltaTime);

    }
}
