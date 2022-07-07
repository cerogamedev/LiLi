using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float dirX = 0f;
    private float a;

    public float FollowSpeed = 2f;
    public float yOffset = 1.3f;
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        if (dirX > 0)
        {
            a = +6;
        }
        if (dirX < 0)
        {
            a = -6;
        }
        Vector3 newPos = new Vector3(target.position.x + a, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);


    }
    

}
