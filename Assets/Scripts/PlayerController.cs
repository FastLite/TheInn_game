using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;

    
    [Header("Stance")] [Tooltip("Height of character when standing")]
    public float capsuleHeightStanding = 1.8f;
    [Tooltip("Height of character when crouching")]
    public float capsuleHeightCrouching = 0.9f;
    float m_TargetCharacterHeight;

    CharacterController characterController;
    public float defaultSpeed = 7.5f;
    public float speedModifier = 1f;
    public float crouchSpeedModifier = 0.75f;
    public float sprintSpeedModifier = 1.25f;

    public float gravity = 20.0f;
    private Vector3 velocity;


    public Transform groundCheck;
    public float groundCheckDistance;
    private bool groundedPlayer;
    private bool isGrounded;
    public LayerMask groundMask;
    
    public bool isCrouched = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        speedModifier = 1;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if (canMove)
            HandleCharacterMovement();
    }

    void HandleCharacterMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * defaultSpeed * speedModifier * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        bool isSprinting = Input.GetButton("Sprint");
        if (isSprinting)
        {
            speedModifier = sprintSpeedModifier;


            if (isCrouched)
            {
                SetCrouchingState(false, false);
            }
        }
        else if (!isCrouched)
            speedModifier = 1;

        if (Input.GetButtonDown("Crouch"))
        {
            SetCrouchingState(!isCrouched, false);
            if (speedModifier == crouchSpeedModifier)
                speedModifier = 1;
            else
            {
                speedModifier = crouchSpeedModifier;
            }
        }
    }


    bool SetCrouchingState(bool crouched, bool ignoreObstructions)
    {
        // set appropriate heights
        if (crouched)
        {
            m_TargetCharacterHeight = capsuleHeightCrouching;
        }
        else
            m_TargetCharacterHeight = capsuleHeightStanding;

        return true;
    }
}