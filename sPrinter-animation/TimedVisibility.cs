using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedVisibility : MonoBehaviour
{

    public int time;
    //public bool state;
    public GameObject objectToActivate;

    // Start is called before the first frame update
    void Start()
    {
        //objectToActivate.SetActive(false);
        StartCoroutine(LateCall(time));
    }


    // Update is called once per frame
    void Update()
    {
       /* if(Time.realtimeSinceStartup >= time)
        {
            gameObject.SetActive(true);
        }*/
    }

 

    IEnumerator LateCall(int timeout)
    {
        
        yield return new WaitForSeconds(timeout);

        objectToActivate.SetActive(!objectToActivate.activeSelf);

       // objectToActivate.SetActive(true);
    }

}
