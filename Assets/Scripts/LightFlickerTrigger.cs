using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerTrigger : MonoBehaviour
{
    public GameObject ml;
    public int time;

    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator turnOf()
    {
        ml.GetComponent<LightFlicker>().enabled = true;
        yield return new WaitForSeconds(time);
        ml.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(nameof(turnOf));
        }
    }
}
