using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
    /*
     * Cameron Dickie
     * January 19th 2018
     * Manages the main menu options 
     */

    public static bool GameIsPaused;

    public GameObject settings;
    public GameObject PauseMenuUI;
    public GameObject gameOver;
    // Update is called once per frame
    private void Start()
    {
        //opens the game and makes sure that the game is running
        GameIsPaused = false;
        Resume();
    }
    void Update () {
        //checks if menu needs to  be opened
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == true)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
	}
    public void SettingsBack()
    {
        settings.SetActive(false);
        PauseMenuUI.SetActive(true);
    }
    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadSettings()
    {
        
        settings.SetActive(true);
        PauseMenuUI.SetActive(false);
    }
    public void GameOver()
    {
        //sets the gamestate to gameover
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
    public void Retry()
    {
        //reloads the first scene (if I add more levels this will be changed)
        SceneManager.LoadScene("MiniGame");
    }
    public void QuitGame()
    {
        //quits the game
        SceneManager.LoadScene("Menu");
    }
}
