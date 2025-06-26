using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SimpleSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sensitivitySlider;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    void Start()
    {
        // Inisialisasi resolusi
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Load dari PlayerPrefs
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.8f);
        sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity", 1.0f);
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void ApplySettings()
    {
        // Simpan volume
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeSlider.value);

        // Simpan sensitivitas
        PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);

        // Simpan resolusi & fullscreen
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, fullscreenToggle.isOn);

        PlayerPrefs.Save();
    }
}
