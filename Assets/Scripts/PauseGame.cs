using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseCanvas;
    private bool pauseActive = false;
    public  AudioListener pLayerListener;

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
                    pauseActive = true;
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    AudioListener.pause = true;
                    Debug.Log(AudioListener.pause);

                    break;
                case true:
                    PauseCanvas.SetActive(false);
                    pauseActive = false;
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    AudioListener.pause = false;
                    Debug.Log(AudioListener.pause);
                    break;
            }
    }

    // Update is called once per frame
    void Update()
    {if (Input.GetKey(KeyCode.Escape))
        PauseUnpause();
    }
}
