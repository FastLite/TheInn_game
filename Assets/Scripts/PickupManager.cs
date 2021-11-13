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
    public Pickup currentKey;
    
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
                GameObject item = hit.collider.gameObject;
                ItemPickedUp(item.GetComponent<Pickup>());
                if (item.GetComponent<Pickup>().type == Pickup.TypeOfPickup.Audio)
                {
                    return;
                }
                item.SetActive(false);
            }
        }
        else if (Physics.Raycast(mainCamera.position, mainCamera.TransformDirection(Vector3.forward), out var hite, raycastDistance) && hite.collider.gameObject.CompareTag("door"))
        {
            pickupHint.SetActive(true);
            Debug.Log("Did Hit door");
            if (Input.GetButton("Interact"))
            {
                Debug.Log("should work now");
                hit.collider.gameObject.GetComponent<Door>().InteractWithDoor(currentKey);
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
        
        switch (item.type)
        {
            case Pickup.TypeOfPickup.Note:
                //show note on the screen ↓
                Instantiate(item.prefab, canvas);
                inventory.Add(item);
                //Pause the game here
                //Add tp journal
                break;
            case Pickup.TypeOfPickup.Audio:
                AudioManager.Instance.PlaySound(gameObject.GetComponent<AudioSource>(),item.sound, 1);
                //Add short description to journal
                break;
            case Pickup.TypeOfPickup.Quest:
                inventory.Add(item);
                currentKey = item;
                Debug.Log("key#" + item.objectID +" picked up and stored instead of " + currentKey);
                //Add required informatio to journal
                break;
        }
    }
    
}
