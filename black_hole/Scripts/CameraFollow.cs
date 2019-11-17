using UnityEngine;
using System.Collections;
 using System;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
 
    Vector3 offset;                     // The initial offset from the target.

    public Move move;
    public Camera camera;
    public float max_x_cam_center;
    public float max_y_cam_center;
    private float init_camera_size;
    void Start ()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
        init_camera_size = camera.orthographicSize;
    }
 
    void FixedUpdate ()
    {

        camera.orthographicSize = init_camera_size + target.localScale.x * 3;
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        max_x_cam_center = move.constrains.x - (float)(camera.orthographicSize*1.9);
        max_y_cam_center = move.constrains.y - (float)(camera.orthographicSize*1.0);

        if (Math.Abs(targetCamPos.x) > max_x_cam_center)
        {
            targetCamPos.x = (targetCamPos.x > 0) ? max_x_cam_center : -max_x_cam_center;
        }
        
        if (Math.Abs(targetCamPos.y) > max_y_cam_center)
        {
            targetCamPos.y = (targetCamPos.y > 0) ? max_y_cam_center : -max_y_cam_center;
        }
       
        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}