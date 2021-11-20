using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrigger : MonoBehaviour
{
    public Animator anim;
    public Door door;
    public GameObject myObject;
    public bool turnOff, lockDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (anim!= null)
        {
            anim.Play(0);
        }

        door.forcedClosed = lockDoor;
        door.animator.SetBool("isOpen", !lockDoor);
        myObject.SetActive(!turnOff);
    }
}
