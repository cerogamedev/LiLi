using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    
    public GameObject pauseMenu;
    public GameObject panel;
    public GameObject pausebutton;



    public GameObject optionsMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);

    }

    void Update()
    {
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        pausebutton.SetActive(true);
        panel.SetActive(false);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        gameIsPaused = true;
        pausebutton.SetActive(true);
        panel.SetActive(true);
        optionsMenu.SetActive(false);
        Time.timeScale = 0f;

    }

    public void LoadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    public void ShowOptions()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        gameIsPaused = true;
    }
    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    public void Quit()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("StartScreen");
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        gameIsPaused = true;
        pausebutton.SetActive(true);
        panel.SetActive(true);
        optionsMenu.SetActive(false);
        Time.timeScale = 0f;
    }
}
