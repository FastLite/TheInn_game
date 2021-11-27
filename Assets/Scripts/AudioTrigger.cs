using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip attachedAudio;
    public AudioSource source;
    public bool ignoreLenght;
    public bool didPlay;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered the trigger");
        if (didPlay) return;
        didPlay = true;
        if (!other.CompareTag("Player")) return;
        if (source==null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
        if (ignoreLenght)
        {
            AudioManager.Instance.PlayMusic(attachedAudio);
        }
        else
            AudioManager.Instance.PlaySound(source,attachedAudio);

    }
}
