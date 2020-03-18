using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // Start is called before the first frame update
    public int startTime, interval;
    //public bool state;
    public GameObject objectToActivate;

    // Start is called before the first frame update

    void Start()
    {

        objectToActivate.SetActive(false);
        StartCoroutine(Activate(startTime));
    }


    // Update is called once per frame
    void Update()
    {
    }



    IEnumerator Activate(int timeout)
    {

        yield return new WaitForSeconds(timeout);

        objectToActivate.SetActive(true);

        StartCoroutine(Deactivate(interval));

    }


    IEnumerator Deactivate(int timeout)
    {

        yield return new WaitForSeconds(timeout);

        objectToActivate.SetActive(false);


    }
}
