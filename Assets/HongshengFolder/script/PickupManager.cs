using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public List<Pickup> inventory = new List<Pickup>();
    
    
    [SerializeField]
    private float raycastDistance = 2;
    public GameObject pickupHint;
    public Transform canvas;
    public Transform mainCamera;
    
    private void FixedUpdate()
    {
        //Check if pickup object is in distance to be picked up
        if (Physics.Raycast(mainCamera.position, mainCamera.TransformDirection(Vector3.forward), out var hit, raycastDistance) && hit.collider.gameObject.CompareTag("pickup"))
        {
            Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit pickup object");
            pickupHint.SetActive(true);
            if (Input.GetButton("Interact"))
            {
                ItemPickedUp(hit.collider.gameObject.GetComponent<Pickup>());
               hit.collider.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward)* hit.distance, Color.red);
            pickupHint.SetActive(false);

        }
    }
    
    
    
    public void ItemPickedUp(Pickup item)
    {   
        inventory.Add(item);
        switch (item.type)
        {
            case Pickup.TypeOfPickup.Note:
                //Take needed audio from item.audiopack SO and play it || Do after making audio system
                Instantiate(item.prefab, canvas);
                //Pause the game here
                //Add tp journal
                break;
            case Pickup.TypeOfPickup.Audio:
                //Take needed audio from item.audiopack SO and play it || Do after making audio system
                //Then play audio recording from that item
                //Add short description to journal
                break;
            case Pickup.TypeOfPickup.Quest:
                //Take needed audio from item.audiopack SO and play it || Do after making audio system
                //Play character voice line
                //Add required informatio to journal
                break;
        }
    }
}
