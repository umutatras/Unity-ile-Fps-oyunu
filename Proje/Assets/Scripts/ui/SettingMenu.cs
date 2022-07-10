using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    private bool isFullscreen=true;
    public void SetResulation(int index)
    {
        if(index==0)
        {
            Screen.SetResolution(1920, 1080, isFullscreen);
        }
        else if(index==1)
        {
            Screen.SetResolution(1366, 728, isFullscreen);
        }
    }
  public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }
    public void SetFullscren(bool fullscreen_enable)
    {
        Screen.fullScreen = fullscreen_enable;
        isFullscreen = fullscreen_enable;
    }
    public void SetMouseSensivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitvity", value);
        if(GameObject.FindGameObjectWithTag("Player")!=null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensitivity = value;
        }
    }
}
