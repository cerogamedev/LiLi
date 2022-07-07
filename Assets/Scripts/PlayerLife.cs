using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static int life = 3;

    public GameObject LastChance;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;


    private Rigidbody2D rb;
    private Animator anim;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();

        SetActiveAll();
        LastChance.SetActive(false);
    }

    private void Update()
    {
        LifeCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {            
            life -= 1;
            transform.position = new Vector2(transform.position.x, transform.position.y + 5f);

        }
        if (life==0)
        {
            Die();
        }

    }
    

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        ItemCollector.chests = 0;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        life = 3;


    }
    
    void LifeCheck()
    {
        if (life ==3)
        {
            SetActiveAll();
        }
        if (life == 2)
        {
            life3.SetActive(false);
        }
        if (life == 1)
        {
            life2.SetActive(false);
            LastChance.SetActive(true);
        }
        if (life==0)
        {
            life1.SetActive(false);
        }
    }

    void SetActiveAll()
    {
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);

    }
}
