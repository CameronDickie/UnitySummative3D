using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    /*
     * Cameron Dickie
     * January 17th 2018
     * Manages the main menu options 
     */
    public GameObject settings;
    public GameObject pauseMenu;
  
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads the next scene in order
    }
    public void Settings()
    {
        //turns off main menu and opens settings
        settings.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void SettingsInGame()
    {
        //turns off main menu and opens settings in game
        settings.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void SettingsBack()
    {
        settings.SetActive(false);
        pauseMenu.SetActive(true);
    }
    
    public void QuitGame()
    {
        //exits game
        Application.Quit();
    }
   
    
}
