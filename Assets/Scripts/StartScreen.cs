using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public float sceneNumberr;
    // Start is called before the first frame update
    void Start()
    {
        sceneNumberr = LevelPass.sceneNumber;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {

        SceneManager.LoadScene("StartStory");



    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetQuality(int qual)
    {

        QualitySettings.SetQualityLevel(qual);

    }

    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }






}
