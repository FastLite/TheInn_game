using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonPause : MonoBehaviour
{
    public GameObject PauseCanvas;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void PauseGame()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PauseCanvas.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }
}
