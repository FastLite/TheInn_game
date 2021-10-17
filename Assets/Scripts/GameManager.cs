using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    public List<Pickup> allPickups = new List<Pickup>();
    public List<Pickup> playerPickedPickups = new List<Pickup>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad (gameObject); 
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void CompareLists()
    {
        //Compare two lists
        foreach (var VARIABLE in playerPickedPickups)
        {
            
        }
        
    }
}
