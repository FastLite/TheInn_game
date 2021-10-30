using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    public bool isDoorOpen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isOpen()
    {
        if (isDoorOpen == false)
        {
            animator.SetBool("isOpen", true);
            isDoorOpen = true;
        }
        else
        {
            animator.SetBool("isOpen", false);
            isDoorOpen = true;
        }
        
    }
}
