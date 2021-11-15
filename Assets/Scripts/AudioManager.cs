using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    public AudioSource player;
    public AudioClip startingMusic;
    public AudioMixer audioMixer;
    
    public void SetVolume(float volume)  //volume slider controller
    {
        audioMixer.SetFloat("volume", volume);
        
    }
    
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
    
    //Play music makes audio source to play several clips at once, so it should be used for music and ambient or long sounds.
    public void PlayMusic(AudioClip clip, float volume)
    {
        //add fade out and fade in here
        player.PlayOneShot(clip, volume);
    }
    
    
    //Play sound forces audiosource to play only one audio clip
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
