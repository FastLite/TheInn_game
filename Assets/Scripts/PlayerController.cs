using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;

    public bool CanMovee
    {
        get => canMove;
        set => canMove = value;
    }

    

    CharacterController characterController;
    public float defaultSpeed = 7.5f;
    private float speedModifier = 1f;
    public float sprintSpeedModifier = 1.25f;

    public bool isSprinting;
    public bool moving;

    public float gravity = 20.0f;
    private Vector3 velocity;
    

    public Transform groundCheck;
    public float groundCheckDistance;
    private bool groundedPlayer;
    private bool isGrounded;
    private bool soundIsPlaying;
    public LayerMask groundMask;

    public Vector3 moveDir;

    public AudioSource footsteps;
    public List<AudioClip> footstepSound;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speedModifier = 1;
    }

    private void Update()
    {
        if (canMove)
            HandleCharacterMovement();
        if (moveDir.x>=0.1 || moveDir.z>=0.1 || moveDir.x<=-0.1 || moveDir.z<=-0.1)
        {
            moving = true;
        }
        else
        {
            moving = false;
            if (footsteps.isPlaying)
            {
                footsteps.Stop();
            }
        }
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
        if (x>0||z>0 |x<.3 |z<.3)
        {
            moveDir = transform.right * x + transform.forward * z;
        }
        else
        {
            moveDir = new Vector3(0,0,0);
        }
        characterController.Move(moveDir * defaultSpeed * speedModifier * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        //Change speed modifer if player holds Sprint button
         isSprinting = Input.GetButton("Sprint");
        if (isSprinting) speedModifier = sprintSpeedModifier;
        if (!isSprinting)
        {
            speedModifier = 1;
        }
        if (moving && !footsteps.isPlaying)
        {
            PlayFootSteps(footstepSound[Random.Range(0,3)]);
        }
    }

    void PlayFootSteps(AudioClip clip)
    {
        footsteps.clip = clip;
        footsteps.Play();
    }
    
 
}