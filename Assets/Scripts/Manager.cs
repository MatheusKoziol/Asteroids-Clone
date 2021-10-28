using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
        Time.timeScale = 1;    
    }
    

    public void Quit()
    {
        Application.Quit();
    }

}
