using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelPass : MonoBehaviour
{
    public GameObject presss;
    public int sifre;
    public int sandýk;
    public  int maxsandýk;
    public string nextlvl;

    public static float sceneNumber=0;

    [SerializeField] private Text maxChestText;


    // Start is called before the first frame update
    void Start()
    {
        presss.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        maxChestText.text = " / " + maxsandýk;
        sandýk = ItemCollector.chests;

        if (sifre == 1 && sandýk >= maxsandýk)
        {
            if (Input.GetKeyDown("s"))
            {
                SceneManager.LoadScene(nextlvl);
                ItemCollector.chests = 0;
            }
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
            sifre = 0;

        }
    }






}
