using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTrigger : MonoBehaviour
{
    public Animator anim;
    public Door door = null;
    public GameObject myObject;
    public bool turnOn, lockDoor, playdoorAnimation;
    private bool didPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (didPlay) return;
        didPlay = true;
        if (anim!= null)
        {
            anim.Play(0);
        }

        if (door!=null)
        {
            Debug.Log("interact with door");
            door.forcedClosed = lockDoor;
            if (playdoorAnimation)
            {
                door.Open(!lockDoor);
            }
        }
        if (myObject!=null)
        {
            myObject.SetActive(turnOn);
        }

    }
}
