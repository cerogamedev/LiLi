using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Boss1 : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    //shooting
    [SerializeField] GameObject bullet;
    float fireRate;
    float nextFire;

    void Start()
    {
        currentHealth = maxHealth;

        this.enabled = true;

        //shooting
        fireRate = 5f;
        nextFire = Time.time;
        
    }
    private void Update()
    {
        CheckIfTimeToFire();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy Dead!!");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("2MainScene");
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
