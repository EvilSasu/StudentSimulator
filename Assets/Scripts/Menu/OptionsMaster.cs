using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMaster : MonoBehaviour
{
    //public AudioMixer audioMixer;
    public AudioController audioController;
    public TMP_Dropdown resolutionDropdown;
    //public Dropdown resolutionDropdown;
    public Slider audioSlider;
    public Toggle FullscreenToggle;
    public AudioVolume audioVolume;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width >= 800 && resolutions[i].width <= 1980)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;

                resolutionOptions.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }       
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("Sounds", audioSlider.value);
        audioController.soundSource.volume = volume;
        audioController.musicSource.volume = volume;
        //audioMixer.SetFloat("volume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen()
    {
        if (FullscreenToggle.isOn)
            Screen.fullScreen = true;
        else
            Screen.fullScreen = false;
    }

    private void Update()
    {
        audioController.soundSource.volume = audioSlider.value;
        audioController.musicSource.volume = audioSlider.value;
        audioVolume.audioVolume = audioSlider.value;
    }
}
