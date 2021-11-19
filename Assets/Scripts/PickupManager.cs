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
    [FormerlySerializedAs("pickupHint")] public GameObject interactHint;
    public Transform canvas;
    public Transform mainCamera;
    public Pickup currentKey;


    private void Start()
    {
        onScreenText.text = "";
        onScreenText.alpha = 0;
    }

    private void Update()
    {
        //Check if pickup object is in distance to be picked up
        if (Physics.Raycast(mainCamera.position, mainCamera.TransformDirection(Vector3.forward), out var hit, raycastDistance, ignoreMe) && hit.collider.gameObject.CompareTag("pickup"))
        {
            Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit pickup object");
            interactHint.SetActive(true);
            if (Input.GetButtonDown("Interact"))
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
                AudioManager.Instance.PlaySound(gameObject.GetComponent<AudioSource>(),item.sound, 1);
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
        onScreenText.alpha = 1;
        onScreenText.text = inputText;
        yield return new WaitForSeconds(2);
        onScreenText.CrossFadeAlpha(0, fadeDuration, true);

    }

   
    
}
