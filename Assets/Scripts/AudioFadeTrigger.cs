using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeTrigger : MonoBehaviour
{
    public AudioClip newTrack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.SwapTrack(newTrack);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.ReturnToDefault();
        }
    }
}
