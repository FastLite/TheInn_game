using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomTrigger : MonoBehaviour
{
    public Animator anim;
    public Door door = null;
    public GameObject myObject;
    public bool turnOn, lockDoor, playdoorAnimation;
    private bool didPlay;
    public UnityEvent myEvent;
    public int delay;
    
    
    
    
    private void Awake()
    {
        if (gameObject.GetComponent<MeshRenderer>() !=null)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (didPlay) return;
        didPlay = true;
        if (myEvent.GetPersistentEventCount()>0)
        {
            Debug.Log(myEvent.GetPersistentEventCount());
            Invoke(nameof(DoEvent), delay);
        }
        if (myObject!=null)
        {
            myObject.SetActive(turnOn);
        }
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
        

        
    }

    private void DoEvent()
    {
        myEvent.Invoke();
        if (delay>0)
        {
            Debug.Log("this was delayed");
        }
    }
    
}
