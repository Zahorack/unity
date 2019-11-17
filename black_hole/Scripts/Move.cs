using UnityEngine;
using System.Collections;

using System;

public class Move : MonoBehaviour 
{
    public float Speed;
    
    public Vector3 constrains;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Target.z = transform.position.z;

            
            if (Math.Abs(transform.position.x) > constrains.x && Math.Abs(Target.x) > constrains.x )
            {
                Target.x = transform.position.x;
            }


            if (Math.Abs(transform.position.y)+1> constrains.y && Math.Abs(Target.y) > constrains.y)
            {
                Target.y = transform.position.y;
            }

            transform.position = Vector3.MoveTowards(transform.position, Target,
                    (  (1000 * Speed * Time.deltaTime) / (transform.localScale.x*2 + 50)));
            
        }
    }
    
}
