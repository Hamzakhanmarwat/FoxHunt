using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject LevelPassPanel, LevelFailPanel;
    // Start is called before the first frame update

    public void Awake()
    {

        LevelFailPanel.SetActive(false);
        LevelPassPanel.SetActive(false);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int sceneID)
    {
        SceneManager.LoadSceneAsync(sceneID);
    }

    public void LoadNextLevel()
    {
        //CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelByName(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LevelFailed()
    {
        LevelFailPanel.SetActive(true);
    }

    public void LevelPassed()
    {
        LevelPassPanel.SetActive(true);
    }
}
