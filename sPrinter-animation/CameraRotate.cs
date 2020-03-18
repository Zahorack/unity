using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public bool IsPressed;
    public GameObject target;//the target object
    private float speedMod = 10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at

    public void TogglePressed(bool value)
    {
        IsPressed = value;
    }

    void Start()
    {//Set up things on the start method
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it
    }

    void Update()
    {
        if (IsPressed)
        {
            transform.RotateAround(target.transform.position, Vector3.up, speedMod * Time.deltaTime);
        }
    }
}