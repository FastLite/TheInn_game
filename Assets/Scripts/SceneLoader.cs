using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public AudioSource clickSound;

    public GameObject loadingScreen;
    public Slider loadingBar;
    public Text progressText;
    private void Start()
    {
        Time.timeScale = 1;
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
            progressText.text = "Loading... " + progress * 100f + "%";
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
}

