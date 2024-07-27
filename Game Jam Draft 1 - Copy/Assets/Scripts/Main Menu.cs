using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void TestLevel()
    {
        SceneManager.LoadScene("TestLevel");
    }
    public void TestLevel2()
    {
        SceneManager.LoadScene("TestLevel1");
    }
}
