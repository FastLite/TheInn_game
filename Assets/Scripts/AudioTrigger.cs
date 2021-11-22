using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip attachedAudio;
    public float volume = 1;
    public AudioSource source;
    public bool ignoreLenght;
    public bool didPlay;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (didPlay) return;
        didPlay = true;
        if (!other.CompareTag("Player")) return;
        if (source==null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
        if (ignoreLenght)
        {
            AudioManager.Instance.PlayMusic(attachedAudio, volume/100);
        }
        else
            AudioManager.Instance.PlaySound(source,attachedAudio, volume/100);

    }
}
