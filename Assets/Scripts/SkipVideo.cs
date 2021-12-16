using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipVideo : MonoBehaviour
{
    public VideoClip vid;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BackToMenu());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    
    // after 25 seconds, game returns back to main menu
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds((float)vid.length);
        SceneManager.LoadScene("MainMenu");
    }
}
