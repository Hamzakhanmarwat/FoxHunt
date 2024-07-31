using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject Level; 

    public void LoadLevelByID(int sceneID)
    {
        //GameManager Script --> SceneManager.LoadSceneAsync(SceneID);
        GameManager.Instance.LoadLevel(sceneID);
    }

    public void LoadNextLevel()
    {
        //GameManager Script --> SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.Instance.LoadNextLevel();
    }


    public void LoadLevelByName(string SceneName)
    {
        //GameManager Script --> SceneManager.LoadSceneAsync(SceneName);
        GameManager.Instance.LoadLevelByName(SceneName);
    }

    public void RestartLevel()
    {
        //GameManager Script --> SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        GameManager.Instance.RestartLevel();
    }
}
