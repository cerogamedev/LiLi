using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMonster : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    Vector3 directionToTarget;
    public float moveSpeed = 2f;
    bool follow = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (follow)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            follow = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            follow = false;

        }
    }
}
