using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject Food;
    public float Speed;

    public Move move;
    void Start()
    {
        InvokeRepeating("Generate", 0, Speed);
    }

    void Generate()
    {
       /*
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = -1;
        */

        int xrand = Random.Range((int)(-move.constrains.x), (int)(move.constrains.x));
        int yrand = Random.Range((int)(-move.constrains.y), (int)(move.constrains.y));
        
        Vector3 Target = new Vector3(xrand, yrand, 0);
        Target.z = -1;

        Instantiate(Food, Target, Quaternion.identity);
    }
}