using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private bool doorOpen = false;
    [SerializeField]
    private bool needKey = false;

    public int keyID;
    public float angle = -120;

    public void RotateDoor(Pickup item)
    {
        if (needKey && !doorOpen)
        {
            Debug.Log("Door needs key #"+keyID);
            if (item.objectID == keyID)
            {
                Debug.Log("Player has the right key");
                Open();
            }
        }
        if (!doorOpen)
        {
            Debug.Log("Door doesn't need a key ");
            Open();
        }
    }

    public void Open()
    {
        animator.SetBool("isOpen", true);
        //transform.GetChild(0).gameObject.transform.Rotate(0.0f, -angle, 0.0f, Space.Self);
        doorOpen = true;
    }

}
