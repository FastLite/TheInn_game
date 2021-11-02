using System;
using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public bool canMove = true;

    CharacterController characterController;
    public float defaultSpeed = 7.5f;
    private float speedModifier = 1f;
    public float sprintSpeedModifier = 1.25f;

    public bool isSprinting;

    public float gravity = 20.0f;
    private Vector3 velocity;
    

    public Transform groundCheck;
    public float groundCheckDistance;
    private bool groundedPlayer;
    private bool isGrounded;
    public LayerMask groundMask;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speedModifier = 1;
    }

    private void Update()
    {
        if (canMove)
            HandleCharacterMovement();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

    }

    void HandleCharacterMovement()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * defaultSpeed * speedModifier * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //Change speed modifer if player holds Sprint button
         isSprinting = Input.GetButton("Sprint");
        if (isSprinting) speedModifier = sprintSpeedModifier;
        if (!isSprinting)
        {
            speedModifier = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            GameManager.instance.ENDgame(true);
        }
        else
        {
            Debug.Log(other.gameObject.tag);
        }
    }
    
 
}