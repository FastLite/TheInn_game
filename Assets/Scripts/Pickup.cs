using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum TypeOfPickup 
    {
        Note, Audio, Quest
    }

    public TypeOfPickup type;
    public string nameOfItem, description;
    public GameObject self;
    public GameObject prefab;
    public AudioClip sound;
    public int objectID;

    private void Start()
    {
        self = gameObject;
    }

    //Maybe include functionality for notes in here later
    //public void OnPickUp()





}
