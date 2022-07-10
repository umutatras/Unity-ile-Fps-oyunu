using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenager : MonoBehaviour
{
    private bool player_alive = true;
    public GameObject death_effect;
    public AudioClip deadplayer;
    public GameObject hand;
    public GameObject crosshair;
    public GameObject gameovermenu;
    public PauseMenu pause_u;
    public void Death()
    {
        if (player_alive)
        {
            player_alive = false;

            pause_u.isGameOver = true;
            //playerdead
            GetComponent<AudioSource>().PlayOneShot(deadplayer);

            //particleeffect
            Instantiate(death_effect, transform.position, Quaternion.identity);

            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshair.SetActive(false);

            //cursor active
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameovermenu.SetActive(true);

        }

    }
}
