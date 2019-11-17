using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Eat : MonoBehaviour
{
    public string Tag;
    public Text Letters;
    public float Increase;

    public AudioSource eatEffect = null;
    
    float Score = 0;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tag) {
            if (other.gameObject.transform.localScale.x < transform.localScale.x + 10) {
                if (transform.localScale.x <= 50)
                {

                    if(eatEffect != null)
                        eatEffect.Play();
                    
                    if (other.gameObject.transform.localScale.x > 10)
                    {
                        float inc = 1; //other.gameObject.transform.localScale.x;
                        if (other.gameObject.transform.localScale.x > 20) inc = 2;
                        else if (other.gameObject.transform.localScale.x > 20) inc = 2;
                        else if (other.gameObject.transform.localScale.x > 30) inc = 3;
                        else if (other.gameObject.transform.localScale.x > 40) inc = 4;
                        
                        if ((transform.localScale.x) <= 50)
                            transform.localScale += new Vector3(inc, inc, inc);
                    }
                    else
                    {
                        transform.localScale += new Vector3(Increase, Increase, Increase);
                    }
                }

                Destroy(other.gameObject); 
                
            }


            Score = transform.localScale.x - 7;
            Letters.text = "SCORE: " + Score;
        }

        if (other.gameObject.tag == "Player")
        {
            if (transform.localScale.x > (other.gameObject.transform.localScale.x +2))
            {
                GUIManager gui = FindObjectOfType<GUIManager>();
                gui.Lose();
                //SceneManager.LoadScene(1);
            }
        }
    }
    
}