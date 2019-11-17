using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

enum EndOfGame
{
    WinState = 0,
    LoseState,
    
    Invalid
}

public class GUIManager : MonoBehaviour
{
    public GameObject LoseText = null;
    public GameObject LoseTextByScore = null;
    public GameObject WinText = null;

    private bool IsWaitng = false;
    EndOfGame state = EndOfGame.Invalid;

    // Update is called once per frame
    void Update()
    {
        if (IsWaitng)
        {

            StartCoroutine(waiter());

            if(state == EndOfGame.LoseState)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            else if (state == EndOfGame.WinState)
            {
                if (SceneManager.GetActiveScene().buildIndex == 6)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void Lose()
    {
        LoseText.SetActive(true);
        IsWaitng = true;
        if(state == EndOfGame.Invalid)
            state = EndOfGame.LoseState;
    }
    
    public void LoseByScore()
    {
        LoseTextByScore.SetActive(true);
        IsWaitng = true;
        
        if(state == EndOfGame.Invalid)
            state = EndOfGame.LoseState;
    }

    public void Win()
    {
        WinText.SetActive(true);
        IsWaitng= true;
        if(state == EndOfGame.Invalid)
            state = EndOfGame.WinState;
    }
    

    IEnumerator waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(4);
        yield return new WaitForSecondsRealtime(2);

    }
    

}
