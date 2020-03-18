using UnityEngine;
using UnityEngine.SceneManagement;



public class NextScene : MonoBehaviour
{

    public string sceneName;

    public void LoadSceneByName()
    {
        SceneManager.LoadScene(sceneName);
    }
}