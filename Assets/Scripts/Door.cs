using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private bool doorOpen = false;
    public bool doorCanBeClosed = true;
    public bool forcedClosed = false;
    
    [SerializeField]
    private bool needKey = false;

    public int keyID;
    public float angle = -120;

    public AudioSource creak;

    public string InteractWithDoor(Pickup item)
    {
        if (forcedClosed)
        {
            Debug.Log("door is closed by developer");
            return "Seems like door is closed from the other side";
        }
        if (needKey && !doorOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("wait"))
        {
            Debug.Log("Door needs key #"+keyID);
            if (item.objectID != keyID)
                return "This door is locked, I gotta find a key" ;
            
            Open(true);
            return "That was the right key";
        }
        if (!doorOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("wait"))
        {
            Debug.Log("Door doesn't need a key ");
            Open(true);
            return null ;
        }
        if (doorOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("open") &&doorCanBeClosed)
        {
            Debug.Log("Door is closing");
            Open(false);
            return null ;
        }
        return null ;
    }

    public void Open(bool isOpen)
    {
        animator.SetBool("isOpen", isOpen);
        doorOpen = !doorOpen;
        creak.Play();
    }

}
