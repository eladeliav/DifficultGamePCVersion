using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class SettingMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public Slider volumeSlider;

    public Toggle fullScreenToggle;

    Resolution[] resolutions;
    
    public Dropdown resolutionDropdown;

    private void Update()
    {
        float realVolume;
        audioMixer.GetFloat("volume", out realVolume);
        AudioListener.volume =  1- (Mathf.Abs(realVolume / 80));
    }

    private void Start()
    {
        float realVolume;
        audioMixer.GetFloat("volume", out realVolume);
        if(volumeSlider != null)
        {
            volumeSlider.value = realVolume;
        }
        

        if(fullScreenToggle != null)
        {
            if (Screen.fullScreen)
            {
                fullScreenToggle.isOn = true;
            }
            else
            {
                fullScreenToggle.isOn = false;
            }
        }
        

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolitionindex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolitionindex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolitionindex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
