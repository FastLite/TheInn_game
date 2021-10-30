using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private bool doorOpen = false;

    public void rotateDoor()
    {
        if (!doorOpen)
        {
            animator.SetBool("isOpen", true);
            //transform.GetChild(0).gameObject.transform.Rotate(0.0f, -120.0f, 0.0f, Space.Self);
            doorOpen = true;
        }
        else
        {
            animator.SetBool("isOpen", false);
            doorOpen = false;
        }
    }

}
