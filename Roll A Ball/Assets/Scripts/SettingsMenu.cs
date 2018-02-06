using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
    /*
     * Cameron Dickie
     * January 19th 2018
     * Manages the settings options along with things like screen resolution, fullscreen settings etc. 
     */
    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public Dropdown ResolutionDropdown;
    void Start()
    {
        resolutions = Screen.resolutions; // assigns the array to all possible resolutions on display

        ResolutionDropdown.ClearOptions(); // clears all previously existing options for the dropdown

        int currentResolutionIndex = 0;

        List<string> options = new List<string>(); //creates a list of all possible resoltion options as a string

        //runs through the resolutions and assigns it to a string value, and finds the highest possible resolution
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //adds in all the possible options to the dropdown and assigns the current value to  the higheset possible option
        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }
    public void SetVolume (float volume)
    {
        //assigns the  game volume to the db of the slider ranging from -80 to 0
        audioMixer.SetFloat("volume", volume);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        //sets the game to fullscreen on toggle
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        //sets the current resolution given the resolution index of the array
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
