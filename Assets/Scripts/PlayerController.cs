using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController charCon;
    
    public float moveSpeed = 5f;
    public float jumpForce = 15f;

    private Vector3 moveDirection;

    private float gravityScale = 5f;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveDirection.y;

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection *= moveSpeed;

        moveDirection.y = yStore;

        if(Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        //transform.position += moveDirection * Time.deltaTime * moveSpeed;
        charCon.Move(moveDirection * Time.deltaTime);
    }
}
