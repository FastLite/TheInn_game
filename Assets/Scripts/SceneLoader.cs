using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public AudioSource clickSound;

    public GameObject loadingScreen;
    public Slider loadingBar;
    public TextMeshProUGUI progressText;
    private void Start()
    {
        Time.timeScale = 1;
        MainMenuCursor();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnLoadSceneCalled(int sceneNum)
    {
        // It will load any scene in the build settings
        SceneManager.LoadScene(sceneNum);
    }

    public void LoadingScreenLoader (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        loadingScreen.SetActive(true);
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        //This will load a scene at the same time as another scene being open.
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.value = progress;
            progressText.text = "Loading... " + (progress * 100).ToString("#.00") + "%";
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenuCursor()
    {
        //if scene is on main menu, cursor unlocked
        if (SceneManager.GetSceneAt(0).isLoaded)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

