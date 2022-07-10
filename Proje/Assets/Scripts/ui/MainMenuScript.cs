using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Start_btn()
    {
        SceneManager.LoadScene("MainS");

    }
    public void Exit_btn()
    {
        Application.Quit();
    }

}
