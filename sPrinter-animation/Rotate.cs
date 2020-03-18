using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotation;
    public Vector3 axes;
    public Transform around;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(axes, 20);

        //  transform.RotateAround(transform.position, transform.right, rotation.x);
        //transform.RotateAround(transform.position, transform.up, rotation.y);
        // transform.RotateAround(transform.position, transform.forward, rotation.z);



        //transform.RotateAround(around.position, Vector3.forward, 20);


    }

    // Update is called once per frame
    void Update()
    {
        Transform par = transform.parent.transform;
        //transform.rotation = Quaternion.Identity;
        //transform.RotateAround(transform.position, transform.right, rotation.x);
        //transform.RotateAround(transform.position, transform.up, rotation.y);
        //transform.RotateAround(transform.position, transform.forward, rotation.z);
        // transform.Rotate(Vector3.up * Time.deltaTime);

        transform.Rotate(0, 0, 1, Space.Self);
    }
}
