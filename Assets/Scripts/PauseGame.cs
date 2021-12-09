using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject settingsCanvas;
    public GameObject overlayCam;
    public GameObject mainCam;
    private bool pauseActive = false;
    public  AudioListener pLayerListener;
    public GameObject note;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    public void PauseUnpause()
    {
            switch (pauseActive)
            {
                case false:
                    PauseCanvas.SetActive(true);
                    settingsCanvas.SetActive(false);
                    //overlayCam.SetActive(false);
                    pauseActive = true;
                   // overlayCam.GetComponent<CameraLookAround>().enabled = false;

                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    AudioListener.pause = true;
                    break;
                case true:
                    //overlayCam.SetActive(true);
                    PauseCanvas.SetActive(false);
                    settingsCanvas.SetActive(false);
                    //overlayCam.GetComponent<CameraLookAround>().enabled = true;
                    pauseActive = false;
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    AudioListener.pause = false;
                    break;
            }
    }

    // Update is called once per frame
    void Update()
    {if (Input.GetKeyDown(KeyCode.Escape) && !note.activeInHierarchy)
        PauseUnpause();
    }
}
