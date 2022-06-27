using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject endScreen;
    public bool gameIsEnded = false;
    public Slider sensativity;
    public Slider volume;
    public GameObject UIPointer;
    
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
        
        volume.value = PlayerPrefs.GetFloat("Volume");

        
        sensativity.value = PlayerPrefs.GetFloat("sensitivity");
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
    public void ChangeSensitivity(float newValue)
    {
        PlayerPrefs.SetFloat("sensitivity", newValue);
    }
    public void ChangeVolume(float newValue)
    {
        PlayerPrefs.SetFloat("Volume", newValue);
    }
    public void saveMuteState(int muted)
    {
        PlayerPrefs.SetInt("MuteState",muted);

    }

}
