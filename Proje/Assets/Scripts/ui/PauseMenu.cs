using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;
    public GameObject Pausemenu_obj;
    public bool isGameOver = false;
    public GameObject player, pistol;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)&& !isGameOver)
        {
            if(!isGamePaused)
            {

                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    private void Pause()
    {

        Time.timeScale = 0;
        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Pausemenu_obj.SetActive(true);
        isGamePaused = true;
    }
    private void Resume()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        Pausemenu_obj.SetActive(false);
        isGamePaused = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
