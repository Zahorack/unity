using UnityEngine;
using System.Collections;

using System;
using System.Net.Mime;

public class LabelController : MonoBehaviour
{

    public GameObject player;
    public String text;
    private Vector3 offset;

    private void Start()
    {
        offset = player.transform.position - transform.position ;
    }

    void Update()
    {
        //float delta = player.transform.localScale.x *4;
        //transform.position = player.transform.position + new Vector3(0,delta,0);//+ offset;
    }
    
    void OnGUI ()
    {
        GUI.Box (new Rect (player.transform.localScale.x, player.transform.localScale.y, 160, 25), text);
    }
}