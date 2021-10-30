using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject endScreen;
    public bool gameIsEnded = false;
    
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
    }

    private void CompareLists()
    {
        //Compare two lists
        foreach (var VARIABLE in playerPickedPickups)
        {
            
        }
        
    }

    public void ENDgame(bool isWin)
    {
        if (isWin)
        {
            endScreen.SetActive(true);            
        }
        else
        {
            //respawn player
        }

    }
    
}
