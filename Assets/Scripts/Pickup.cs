using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum TypeOfPickup 
    {
        Note, Audio, Quest, Scare,
    }

    public TypeOfPickup type;
    public string nameOfItem, description;
    public GameObject self;
    public GameObject prefab;
    public AudioClip sound;
    public int objectID;
    public string noteText;

    private void Start()
    {
        self = gameObject;
    }

    //Maybe include functionality for notes in here later
    //public void OnPickUp()





}
