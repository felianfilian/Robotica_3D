using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 20f;

    private Vector3 moveDirection;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if(Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        transform.position += moveDirection * Time.deltaTime * moveSpeed;
    }
}
