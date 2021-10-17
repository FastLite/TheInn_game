using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public bool canMove = true;

    
    [Header("Stance")] [Tooltip("Modifier of character height when standing")]
    public float capsuleHeightStanding = 1f;
    [Tooltip("Height of character when crouching")]
    public float capsuleHeightCrouching = 0.5f;

    CharacterController characterController;
    public float defaultSpeed = 7.5f;
    public float speedModifier = 1f;
    public float crouchSpeedModifier = 0.75f;
    public float sprintSpeedModifier = 1.25f;

    public bool isSprinting;

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
        capsuleHeightStanding = characterController.height;
        speedModifier = 1;
        
        Debug.Log("Starting state "+ isCrouched +"  Starting speed "+ speedModifier);
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
        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * defaultSpeed * speedModifier * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
      
        
        
        //Change speed modifer if player holds Sprint button
         isSprinting = Input.GetButton("Sprint");
        if (isSprinting)
        {
            speedModifier = sprintSpeedModifier;

            //If player is crouched force him to get up
            if (isCrouched)
            {
                SetCrouchingState(false, false);
            }
        }

        if (Input.GetButtonDown("Crouch"))
        {
            
            isCrouched = !isCrouched;

        
         //SetCrouchingState(!isCrouched, false);
            if (speedModifier == crouchSpeedModifier)
                speedModifier = 1;
            else
            {
                speedModifier = crouchSpeedModifier;
            }
            Debug.Log("New crouch state is "+ isCrouched +"  New speed Modifier is "+ speedModifier);
        }
        float newHeight = capsuleHeightStanding;
        if (isCrouched)
        {
            newHeight = capsuleHeightCrouching;
        }

        float previousHeight = characterController.height;
        characterController.height = Mathf.Lerp(characterController.height, newHeight, 10 * Time.deltaTime);
            transform.Translate(0,(characterController.height-previousHeight)*capsuleHeightCrouching,0);
        if (!isCrouched && !isSprinting)
        {
            speedModifier = 1;
        }
    }
    
    


    bool SetCrouchingState(bool crouched, bool ignoreObstructions)
    {
        // set appropriate heights
        if (crouched)
        {
            //adjust character controller height
             
        }
        else
            gameObject.transform.localScale = new Vector3(transform.localScale.x,1,transform.localScale.z);
        return true;
    }
 
}