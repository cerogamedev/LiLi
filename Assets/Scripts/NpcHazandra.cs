using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcHazandra : MonoBehaviour
{
    // Start is called before the first frame update
    public int prime = 1;
    public int password;

    public Text text1;
    public GameObject hazandrapicture;
    public GameObject presss;
    public GameObject textbg;
    public GameObject chbg;
    public GameObject button1;


    // Start is called before the first frame update
    void Start()
    {
        presss.SetActive(false);
        hazandrapicture.SetActive(false);
        textbg.SetActive(false);
        chbg.SetActive(false);
        button1.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


        if (password == 1)
        {
            if (Input.GetKeyDown("s"))
            {
                prime = 2;
                hazandrapicture.SetActive(true);
                textbg.SetActive(true);
                chbg.SetActive(true);
                button1.SetActive(true);

            }
        }



        if (prime == 2)
        {
            text1.text = "hi!";
        }
        if (prime == 3)
        {
            text1.text = "whats up?";
        }
        if (prime == 4)
        {
            text1.text = "If you see someone like me, please let me know.";
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            presss.SetActive(true);
            password = 1;

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            presss.SetActive(false);
            hazandrapicture.SetActive(false);
            textbg.SetActive(false);
            chbg.SetActive(false);
            button1.SetActive(false);

            prime = 1;
            password = 0;

            text1.text = "";
        }

    }

    public void Talker()
    {
        prime += 1;
    }
}
