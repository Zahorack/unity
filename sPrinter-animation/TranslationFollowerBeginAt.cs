using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationFollowerBeginAt : MonoBehaviour
{
    public int time;
    public GameObject follow;

    private bool enable = false;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(LateCall(time));
    }

    // Update is called once per frame
    void Update()
    {
        if(enable == true)
            transform.position = follow.transform.position + offset;
    }

    IEnumerator LateCall(int timeout)
    {

        yield return new WaitForSeconds(timeout);

        enable = true;
        offset = transform.position - follow.transform.position;
    }
}

