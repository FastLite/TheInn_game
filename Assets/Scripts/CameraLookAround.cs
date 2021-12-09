using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAround : MonoBehaviour
{
    
    public float sensitivity = 2.0f;
    private float xRotation = 0;
    public Transform playerBody;
    public Transform highlightCamera;

    void Start()
    {
        if (PlayerPrefs.GetFloat(nameof(sensitivity)) < 20) 
        {
            PlayerPrefs.SetFloat(nameof(sensitivity), 100);

        }
        sensitivity = PlayerPrefs.GetFloat(nameof(sensitivity));
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        xRotation += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp( xRotation,-80, 85);
        transform.eulerAngles = new Vector3(-xRotation, transform.eulerAngles.y+mouseX, 0);
        highlightCamera.eulerAngles = transform.eulerAngles;
        playerBody.eulerAngles = new Vector3(0, playerBody.eulerAngles.y+mouseX, 0);
    }

    public void ChangeSensitivity(float newValue)
    {
        PlayerPrefs.SetFloat(nameof(sensitivity), newValue);
        sensitivity = newValue;
        Debug.Log(sensitivity);
    }

    
}
