using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    public AudioSource player;
    public AudioClip startingMusic;
	
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad (gameObject);
        
        PlayMusic(startingMusic, 1);
    }
    
    public void PlayMusic(AudioClip clip, float volume)
    {
        //add fade out and fade in here
        player.PlayOneShot(clip, volume);
    }
    
    public void PlaySound(AudioSource src, AudioClip clip, float volume)
    {
        src.clip = clip;
        if (volume>0)
        {
            src.volume = volume;
        }
        
        src.Play();
        
    }
}
