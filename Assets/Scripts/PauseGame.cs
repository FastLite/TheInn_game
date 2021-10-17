using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseCanvas;
    private bool pauseActive = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void PauseUnpause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            switch (pauseActive)
            {
                case false:
                    PauseCanvas.SetActive(true);
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    break;
                case true:
                    PauseCanvas.SetActive(false);
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        PauseUnpause();
    }
}
