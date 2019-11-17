using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using UnityEditor;

using UnityEngine;
using UnityEngine.SceneManagement;
using Color = UnityEngine.Color;


public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource endSound = null;
    
    public List<GameObject> players = new List<GameObject>();
    public int HighScore = 50;
    private EnemyMovement mov;
    void Start()
    {
        endSound = GameObject.Find("WinSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < players.Count; i++)
        {
            
            if ((players[i].transform.localScale.x - 7) >= HighScore)
            {
                GUIManager gui = FindObjectOfType<GUIManager>();
                
                if (players[i].tag == "Enemy")
                {
                    endSound.Play();
                    gui.LoseByScore();
                }
                else if(players[i].tag == "Player")
                {
                    endSound.Play();
                    gui.Win();
                }
            }
        }
    }
        
    
    void OnGUI ()
    {
        GUI.Box(new Rect(920, 0, 180, 25), "Table              /" + HighScore.ToString());

        List<GameObject> orderedPlayers= players.OrderBy(o => o.transform.localScale.x).ToList();
        
        
        for (int i = 0, enem = players.Count -1; enem >= 0; i++, enem--)
        {
            String inteligence = " ( ? )";
            
           GUI.contentColor = Color.white;
            if(orderedPlayers[enem].name == "BlackHole")
                GUI.contentColor = Color.cyan;
            else
            {
                mov = orderedPlayers[enem].GetComponent<EnemyMovement>();
                if (mov.inteligence == EnemyInteligence.Dumy)
                    inteligence = " (Dummy)";
                else
                    inteligence = " (Smart)";
            }
            
            GUI.Box(new Rect(920, (i+1)*25, 120, 25), orderedPlayers[enem].name.ToString() + inteligence);
            GUI.Box(new Rect(1040, (i+1)*25, 50, 25), ((orderedPlayers[enem].transform.localScale.x - 7).ToString("N1")));
        }
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }

    void repeatScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
}
