using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhellsController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool direction = true;
    public float speed = 0;
    public Vector3 axes;

    public Transform predne, stredne, zadne;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        predne.Rotate(axes, direction ? Time.deltaTime * speed : -Time.deltaTime * speed);
        stredne.Rotate(axes, direction ? Time.deltaTime * speed : -Time.deltaTime * speed);
        zadne.Rotate(axes, direction ? Time.deltaTime * speed : -Time.deltaTime * speed);
    }
}
