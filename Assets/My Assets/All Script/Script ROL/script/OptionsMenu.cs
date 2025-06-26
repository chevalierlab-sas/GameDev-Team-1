using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    
    public Slider volumeSlider, sensitivitySlider;
    public SC_FPSController player;
    public Camera playerCam;

    void Start()
    {
        if (!PlayerPrefs.HasKey("gameLaunched"))
        {
           
            PlayerPrefs.SetFloat("masterVolume", 1);
            PlayerPrefs.SetFloat("mouseSensitivity", 3);
           
            PlayerPrefs.SetInt("gameLaunched", 0);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("gameLaunched"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
            AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");

            sensitivitySlider.value = PlayerPrefs.GetFloat("mouseSensitivity");
            player.lookSpeed = PlayerPrefs.GetFloat("mouseSensitivity");

            
        }
    }
    
    public void setVolume()
    {
        PlayerPrefs.SetFloat("masterVolume", volumeSlider.value);
        PlayerPrefs.Save();
        AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
    }
    public void setSensitivity()
    {
        PlayerPrefs.SetFloat("mouseSensitivity", sensitivitySlider.value);
        PlayerPrefs.Save();
        player.lookSpeed = PlayerPrefs.GetFloat("mouseSensitivity");
    }
}