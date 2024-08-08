using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{

    public GameObject PlayerGameObject, TutorialPanel;
    // Start is called before the first frame update

    public void Awake()
    {
        PlayerGameObject.SetActive(false);
    }


    public void EndOfTutorial()
    {
        PlayerGameObject.SetActive(true);
        Destroy(TutorialPanel);
    }
    
}
