using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public CharacterController charCon;
    public GameObject playerModel;
    public Animator animator;
    
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public float rotateSpeed = 5f;

    private Vector3 moveDirection;
    private new Camera camera;

    private float gravityScale = 5f;

    // knockback
    private bool isKnocking = false;
    private float knockbackTime = 0.5f;
    private float knockbackCounter;
    private Vector2 knockbackPower;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Animation();
        
    }

    public void Move()
    {
        float yStore = moveDirection.y;

        //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
        moveDirection *= moveSpeed;

        moveDirection.y = yStore;

        if (charCon.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }


        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        //transform.position += moveDirection * Time.deltaTime * moveSpeed;
        charCon.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, camera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }

    public void Animation()
    {
        animator.SetFloat("speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        animator.SetBool("grounded", charCon.isGrounded);
    }

    public void KnockBack()
    {
        isKnocking = true;
        knockbackCounter = knockbackTime;
        Debug.Log("knock back");
    }
}
