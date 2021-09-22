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

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;
        if (source==null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
        if (attachedAudio.length > 20 || ignoreLenght)
        {
            AudioManager.Instance.PlayMusic(attachedAudio, volume/100);
        }
        else
            AudioManager.Instance.PlaySound(source,attachedAudio, volume/100);

    }
}
