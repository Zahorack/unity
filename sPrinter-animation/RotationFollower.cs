using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFollower : MonoBehaviour
{
    public GameObject follow;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.rotation.eulerAngles - follow.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 difference = (follow.transform.rotation.eulerAngles + offset) - transform.rotation.eulerAngles;

        if (!difference.Equals(0))
        {
            transform.Rotate((difference), Space.World);
        }
    }
}
