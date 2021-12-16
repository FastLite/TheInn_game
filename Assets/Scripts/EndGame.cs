using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private bool skipCredits = false;
    // Start is called before the first frame update
    void Start()
    {
        if (skipCredits)
         StartCoroutine(BackToMenu());
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && skipCredits)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // after 25 seconds, game returns back to main menu
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(35f);
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTriggerEnter(Collider other)
    {
        skipCredits = true;
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
