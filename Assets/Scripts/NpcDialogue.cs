using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogue : MonoBehaviour
{
    public int primelnt = 1;
    public int sifre;

    public Text text1;

    public Text button1text;
    public Text button2text;

    public GameObject cspicture;
    public GameObject presss;
    public GameObject textbg;
    public GameObject chbg;
    public GameObject button1;

    public GameObject buttonchs1;
    public GameObject buttonchs2;


    // Start is called before the first frame update
    void Start()
    {
        presss.SetActive(false);
        cspicture.SetActive(false);
        textbg.SetActive(false);
        chbg.SetActive(false);
        button1.SetActive(false);
        buttonchs1.SetActive(false);
        buttonchs2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


        if (sifre == 1)
        {
            if (Input.GetKeyDown("s"))
            {
                primelnt = 2;
                cspicture.SetActive(true);
                textbg.SetActive(true);
                chbg.SetActive(true);
                button1.SetActive(true);

            }
        }



        if (primelnt == 2)
        {
            text1.text = "hello stranger";
        }
        if (primelnt == 3)
        {
            text1.text = "Looks like you're a eminent warrior. What are you doing around here?";
        }
        if (primelnt == 4)
        {
            text1.text = "";

            buttonchs1.SetActive(true);
            buttonchs2.SetActive(true);
            button1.SetActive(false);


            button1text.text = "Tell your true purpose";
            button2text.text = "Ignore him";


        }
        if (primelnt == 5)
        {
            buttonchs1.SetActive(false);
            buttonchs2.SetActive(false);
            button1.SetActive(true);
            text1.text = "Ow. You know, villages and cities were bewitched by dark magicians.";
        }
        if (primelnt == 6)
        {
            text1.text = "We are the last survivors here.";
        }
        if (primelnt == 7)
        {
            text1.text = "Do you want a any advice?";
        }

        if (primelnt == 8)
        {
            text1.text = "";

            buttonchs1.SetActive(true);
            buttonchs2.SetActive(true);
            button1.SetActive(false);


            button1text.text = "I'm listening to you.";
            button2text.text = "Ignore him";


        }
        if (primelnt == 9)
        {
            buttonchs1.SetActive(false);
            buttonchs2.SetActive(false);
            button1.SetActive(true);
            text1.text = "Obviously, you can't jump too much because of your armor.";
        }


        if (primelnt == 10)
        {
            text1.text = "So take a good look at the 'jump limit' at the top left.";
        }
        if (primelnt == 11)
        {
            text1.text = "Also, you can't finish a level without find a .";
        }
        if (primelnt == 12)
        {
            text1.text = "and I'm going on a trip too";
        }
        if (primelnt == 13)
        {
            text1.text = "I hope so, we can meet again. Good bye!";
        }
        if (primelnt == 14)
        {
            Ignore();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            presss.SetActive(true);
            sifre = 1;

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            presss.SetActive(false);
            cspicture.SetActive(false);
            textbg.SetActive(false);
            chbg.SetActive(false);
            button1.SetActive(false);
            buttonchs1.SetActive(false);
            buttonchs2.SetActive(false);

            primelnt = 1;
            sifre = 0;

            text1.text = "";
        }

    }
    public void Ignore()
    {
        presss.SetActive(false);
        cspicture.SetActive(false);
        textbg.SetActive(false);
        chbg.SetActive(false);
        button1.SetActive(false);
        buttonchs1.SetActive(false);
        buttonchs2.SetActive(false);

        sifre = 0;

        text1.text = "";

    }
    public void Talking()
    {
        primelnt += 1;
    }
    


}
