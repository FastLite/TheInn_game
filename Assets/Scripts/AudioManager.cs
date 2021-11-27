using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource ambAudio;
    public AudioSource chaseMusic;
    public static AudioManager Instance = null;
    public AudioSource player;
    public AudioClip startingMusic;
    public AudioMixer audioMixer;
    public bool isAmbPlaying;
    public AudioClip defaultAmb;
    
    public void SetVolume(float volume)  //volume slider controller
    {
        audioMixer.SetFloat("volume", volume);
        
    }

    private void Start()
    {
        isAmbPlaying = true;
        SwapTrack(defaultAmb);
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
        
        PlayMusic(startingMusic);
    }
    
    //Play music makes audio source to play several clips at once, so it should be used for music and ambient or long sounds.
    public void PlayMusic(AudioClip clip)
    {
        //add fade out and fade in here
        player.PlayOneShot(clip);
    }
    
    
    //Play sound forces audiosource to play only one audio clip
    public void PlaySound(AudioSource src, AudioClip clip )
    {
        src.clip = clip;
        src.Play();
    }

    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack (newClip));        

        isAmbPlaying = !isAmbPlaying;
    }
    public void ReturnToDefault()
    {
        SwapTrack(defaultAmb);
    }
    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 1.0f;
        float timeTaken = 0;
        if (isAmbPlaying)
        {
            chaseMusic.clip = newClip;
            chaseMusic.Play();
            while (timeTaken < timeToFade)
            {
                chaseMusic.volume = Mathf.Lerp(0, 1, timeTaken / timeToFade);
                ambAudio.volume = Mathf.Lerp(1, 0, timeTaken / timeToFade);
                timeTaken += Time.deltaTime;
                yield return null;
            }
            ambAudio.Stop();
        }
        else
        {
            ambAudio.clip = newClip;
            ambAudio.Play();
            while (timeTaken < timeToFade)
            {
                ambAudio.volume = Mathf.Lerp(0, 1, timeTaken / timeToFade);
                chaseMusic.volume = Mathf.Lerp(1, 0, timeTaken / timeToFade);
                timeTaken += Time.deltaTime;
                yield return null;
            }
            chaseMusic.Stop();
        }
    }
}
