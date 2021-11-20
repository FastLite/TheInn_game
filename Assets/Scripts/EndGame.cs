using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BackToMenu());
    }

    // after 25 seconds, game returns back to main menu
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(25f);
        SceneManager.LoadScene(0);
    }
}
