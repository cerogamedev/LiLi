using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int chests = 0;

    [SerializeField] private Text chesttext;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            Destroy(collision.gameObject);
            chests++;
            chesttext.text = "" + chests;
        }
    }
}
