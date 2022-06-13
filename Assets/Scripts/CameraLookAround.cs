using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAround : MonoBehaviour
{
    
    public float sensitivity = 10;
    private float upDownRotation = 0;
    public Transform playerBody;

    void Start()
    {
        if (PlayerPrefs.GetFloat(nameof(sensitivity)) < 5) 
        {
            PlayerPrefs.SetFloat(nameof(sensitivity), 10);

        }
        sensitivity = PlayerPrefs.GetFloat(nameof(sensitivity));
        sensitivity = 10;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
       if (Input.GetJoystickNames().Length == 0)
       {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            upDownRotation -= mouseY;
            upDownRotation = Mathf.Clamp( upDownRotation,-80, 85);
            transform.localRotation = Quaternion.Euler(upDownRotation, 0, 0);
           playerBody.Rotate(Vector3.up * mouseX);    
       }
       else
       {
            if (Input.GetAxis("Joystick right X") > .2f ||(Input.GetAxis("Joystick right X") <-0.2f))
            {
                
               // float joystickX = Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime;
               playerBody.Rotate(Vector3.up * Input.GetAxis("Joystick right X") * (sensitivity/10));

            }
            if (Input.GetAxis("Joystick right Y")> .2f )
            {
                if (transform.localRotation.x * 130 <80) //>-80
                {
                    RotateVertical();
                    Debug.Log("going down");
                }
                
            }
            else if (Input.GetAxis("Joystick right Y")< -0.2f && transform.rotation.x < 80)
            {
                if (transform.localRotation.x * 130 >-80) //<80)
                {
                    RotateVertical();
                    
                }
                
            }
            //playerBody.Rotate(upDownRotation, joystickY, 0);  
       }
        

        
        
        
    }

    private void RotateVertical()
    {
        var rot = Mathf.Clamp(Input.GetAxis("Joystick right Y") * (sensitivity / 10) * -1, -80, 85);
        transform.Rotate(Vector3.left * rot);
    }
    public void ChangeSensitivity(float newValue)
    {
        PlayerPrefs.SetFloat(nameof(sensitivity), newValue);
        sensitivity = newValue;
        Debug.Log(sensitivity);
    }

    
}
