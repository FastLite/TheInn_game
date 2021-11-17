using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private bool doorOpen = false;
    private bool doorCanBeClosed = true;
    
    [SerializeField]
    private bool needKey = false;

    public int keyID;
    public float angle = -120;

    public AudioSource creak;

    public bool InteractWithDoor(Pickup item)
    {
        if (needKey && !doorOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("wait"))
        {
            Debug.Log("Door needs key #"+keyID);
            if (item.objectID != keyID)
                return false ;
            
            Open(true);
            return true ;
        }
        if (!doorOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("wait"))
        {
            Debug.Log("Door doesn't need a key ");
            Open(true);
            return false ;
        }
        else if (doorOpen && animator.GetCurrentAnimatorStateInfo(0).IsName("open"))
        {
            Debug.Log("Door is closing");
            Open(false);
            return false ;
        }
        return false ;
    }

    public void Open(bool isOpen)
    {
        animator.SetBool("isOpen", isOpen);
        doorOpen = !doorOpen;
        creak.Play();
    }

}
