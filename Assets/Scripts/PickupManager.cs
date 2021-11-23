using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{
    public List<Pickup> inventory = new List<Pickup>();
    public GameObject keyImg;
    public LayerMask ignoreMe;
    public TextMeshProUGUI onScreenText;
    public float fadeDuration = 2;

    [SerializeField]
    private float raycastDistance = 2;
    private float waitSecondHint = 4;
    [FormerlySerializedAs("pickupHint")] public GameObject interactHint;
    public Transform canvas;
    public Transform mainCamera;
    public Pickup currentKey;


    private void Start()
    {
        onScreenText.text = "";
        onScreenText.alpha = 1;
    }

    private void Update()
    {
        //Check if pickup object is in distance to be picked up
        if (Physics.Raycast(mainCamera.position, mainCamera.TransformDirection(Vector3.forward), out var hit, raycastDistance, ignoreMe) && hit.collider.gameObject.CompareTag("pickup"))
        {
            Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit pickup object");
            interactHint.SetActive(true);
            if (Input.GetButtonDown("Interact") && hit.collider.gameObject.GetComponent<Pickup>().enabled)
            {
                GameObject item = hit.collider.gameObject;
                ItemPickedUp(item.GetComponent<Pickup>());
                if (item.GetComponent<Pickup>().type == Pickup.TypeOfPickup.Audio)
                {
                    item.GetComponent<Pickup>().enabled = false;
                    var src = item.GetComponent<AudioSource>();
                    src.clip = item.GetComponent<Pickup>().sound;
                    src.Play();
                    return;
                }
                item.SetActive(false);
                
            }
        }
        else if (Physics.Raycast(mainCamera.position, mainCamera.TransformDirection(Vector3.forward), out var hite, raycastDistance) && hite.collider.gameObject.CompareTag("door"))
        {
            interactHint.SetActive(true);
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log(hite.collider.GetComponent<Door>().keyID);
                string currentdoorText = hit.collider.GetComponent<Door>().InteractWithDoor(currentKey);
                if (currentdoorText == null)
                {
                    return;
                }
                StartCoroutine(TextOnScreen(currentdoorText));
                if (currentdoorText == "That was the right key")
                {
                    keyImg.SetActive(false);
                }
            }
        }
        else
        {
            Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward)* hit.distance, Color.red);
            interactHint.SetActive(false);

        }
    }
    
    
    
    private void ItemPickedUp(Pickup item)
    {   
        StartCoroutine(TextOnScreen(item.description));

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
                //Add short description to journal
                break;
            case Pickup.TypeOfPickup.Quest:
                inventory.Add(item);
                currentKey = item;
                keyImg.SetActive(true);

                Debug.Log("key#" + item.objectID +" picked up and stored instead of " + currentKey);
                //Add required informatio to journal
                break;
        }
    }

    IEnumerator TextOnScreen(string inputText)
    {       
        onScreenText.gameObject.SetActive(true);

        onScreenText.text = inputText;
        yield return new WaitForSeconds(waitSecondHint);
        onScreenText.gameObject.SetActive(false);

    }

   
    
}
