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
    [FormerlySerializedAs("name")] public TextMeshProUGUI noteName;
    public TextMeshProUGUI text;
    public GameObject noteGO;
    public AudioSource playerAS;
    public AudioClip notePickUPSound;
    public AudioClip keyPickUPSound;
    public GameObject camera1;
    public GameObject camera2;


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
                    item.layer = 0;
                    item.GetComponent<Pickup>().enabled = false;
                    var src = item.GetComponent<AudioSource>();
                    src.clip = item.GetComponent<Pickup>().sound;
                    src.Play();
                    return;
                }
                item.SetActive(false);
                
            }
        }
        else if (Physics.Raycast(mainCamera.position, mainCamera.TransformDirection(Vector3.forward), out var hite, raycastDistance))
        {
            GameObject obj = hite.collider.gameObject;
            if (obj.CompareTag("door"))
            {
                interactHint.SetActive(true);
                if (Input.GetButtonDown("Interact"))
                {
                    Debug.Log(obj.GetComponent<Door>().keyID);
                    string currentDoorText = obj.GetComponent<Door>().InteractWithDoor(currentKey);
                    StartCoroutine(TextOnScreen(currentDoorText));

                    if (currentDoorText == null)
                    {
                        return;
                    }
                    if (currentDoorText == "That was the right key")
                    {
                        keyImg.SetActive(false);
                    }
                }
            }
            else if(hite.collider.gameObject.CompareTag("Described"))
            {
                if (obj.GetComponent<ItemShowText>().didPLay)
                {
                    return;
                }
                StartCoroutine(TextOnScreen(obj.GetComponent<ItemShowText>().discription));
                obj.GetComponent<ItemShowText>().didPLay = true;
            }
            
        }
        else
        {
            Debug.DrawRay(mainCamera.position, mainCamera.TransformDirection(Vector3.forward)* hit.distance, Color.red);
            interactHint.SetActive(false);

        }

        if (noteGO.activeInHierarchy)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                UnlockAfterNote();
            }
        }
      
            
        
    }
    
    
    
    private void ItemPickedUp(Pickup item)
    {   
        StartCoroutine(TextOnScreen(item.description));

        switch (item.type)
        {
            case Pickup.TypeOfPickup.Note:
                //show note on the screen ↓
                noteName.text = item.nameOfItem;
                text.text = item.noteText;
                noteGO.SetActive(true);
                FindObjectOfType<PlayerController>().canMove = false;
                camera1.GetComponent<CameraLookAround>().enabled = false;
                camera2.GetComponent<CameraLookAround>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                playerAS.PlayOneShot(notePickUPSound);
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
                playerAS.PlayOneShot(keyPickUPSound);

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

    public void UnlockAfterNote()
    {
        noteGO.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PlayerController>().canMove = true;

        camera1.GetComponent<CameraLookAround>().enabled = true;
        camera2.GetComponent<CameraLookAround>().enabled = true;
        FindObjectOfType<PlayerController>().canMove = true;
    }

   
    
}
