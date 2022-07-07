using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CutScene : MonoBehaviour
{
    
    
    [SerializeField] Text text;
    [SerializeField] List<string> lines;

    [SerializeField] [Range(0f, 1f)] float visibleTextPercent;

    [SerializeField] float timePerLetter = 0.04f;
    float totalTimeToType, currentTime;

    string lineToShow;

    // Start is called before the first frame update
    void Start()
    {
        CycleLine();
        

    }

    // Update is called once per frame
    void Update()
    {
        TypeOutText();
        if (Input.GetButtonDown("Jump"))
        {
            PushText();
        }


    }

    void UpdateText()
    {
        int totalLetterToShow = (int)(lineToShow.Length * visibleTextPercent);
        text.text = lineToShow.Substring(0, totalLetterToShow);
    }

    public void PushText()
    {
        if (visibleTextPercent < 1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }
        CycleLine();
    }

    private void TypeOutText()
    {
        if (visibleTextPercent >= 1f)
        {
            return;
        }
        currentTime += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0f, 1f);
        UpdateText();
    }
    private void CycleLine()
    {
        if (lines.Count == 0)
        {
            Debug.Log("There is nothing here");
            SceneManager.LoadScene("MainScene");
            return;
        }
        lineToShow = lines[0];
        lines.RemoveAt(0);

        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;

        //clear the text object
        text.text = "";
    }

    

}
