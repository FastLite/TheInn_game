using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAround : MonoBehaviour
{
    
    public float sensitivity = 2.0f;
    private float xRotation = 0;
    public Transform playerBody;

    void Start()
    {
        if (PlayerPrefs.GetFloat(nameof(sensitivity)) == null || PlayerPrefs.GetFloat(nameof(sensitivity)) == 0) 
        {
            PlayerPrefs.SetFloat(nameof(sensitivity), 100);

        }
        sensitivity = PlayerPrefs.GetFloat(nameof(sensitivity));
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp( xRotation,-80, 85);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);    
    }

    public void ChangeSensitivity(float newValue)
    {
        PlayerPrefs.SetFloat(nameof(sensitivity), newValue);
        sensitivity = PlayerPrefs.GetFloat(nameof(sensitivity));
        Debug.Log(sensitivity);
    }

    
}
