using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUp : MonoBehaviour
{
    public Slider Mouse_slider;
    private void awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitvity",185);
        Mouse_slider.value = PlayerPrefs.GetFloat("MouseSensitvity", 185);
    }
}
