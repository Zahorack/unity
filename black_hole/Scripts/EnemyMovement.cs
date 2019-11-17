using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public enum EnemyInteligence
{
    Smart = 0,
    Dumy
}

public class EnemyMovement : MonoBehaviour 
{
    public float Speed;
    public Move move;
    private int counter;
    Vector3 Target;
    public volatile EnemyInteligence inteligence;
    
    private static float last_score;
    private bool looking_for_player = false;

    private void Start()
    {
        last_score = transform.localScale.x;
        setRandomTarget();
        //Target = FindClosestFood().transform.position;
    }

    void Update()
    {
        counter++;

        if (inteligence == EnemyInteligence.Smart)
        {
            if (IsPlayerNear() != null)
            {
                Target = IsPlayerNear().transform.position;
                looking_for_player = true;
            }
            
            else if (last_score != transform.localScale.x  || counter > 200 || looking_for_player == true)
            {
                Target = FindClosestFood().transform.position;

                last_score = transform.localScale.x;
                looking_for_player = false;

            }
        }
        else if(inteligence == EnemyInteligence.Dumy)
        {
            if (counter > 120)
            {
                setRandomTarget();
            }
        }


        transform.position = Vector3.MoveTowards(transform.position, Target,
            ((1000 * Speed * Time.deltaTime) / (transform.localScale.x*2 + 50)));
        
        
    }

    void setRandomTarget()
    {
        int xrand = Random.Range((int) (-move.constrains.x), (int) (move.constrains.x));
        int yrand = Random.Range((int) (-move.constrains.y), (int) (move.constrains.y));

        Target.x = xrand;
        Target.y = yrand;
        Target.z = transform.position.z;

        counter = 0;
    }
    
    
    public GameObject FindClosestFood()
    {
        GameObject[] gos;
        
        gos = GameObject.FindGameObjectsWithTag("Food");
        
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            
            if (curDistance < distance && (go.transform.localScale.x) < transform.localScale.x)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    
    public GameObject IsPlayerNear()
    {
        GameObject[] gos;
        
        gos = GameObject.FindGameObjectsWithTag("Player");
        
        GameObject closest = null;
        Vector3 position = transform.position;
        
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < 100000.0 && (go.transform.localScale.x +3) < transform.localScale.x)
            {
                closest = go;
            }

        }
        return closest;
    }
}