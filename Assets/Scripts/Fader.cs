using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fader : MonoBehaviour
{
    public Image blackFade;
    public GameObject fadeGO;
    public int fadeDuration;
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(1.0f); //Canvas alpha starts on
        StartCoroutine(FadeIn());
        
    }
    IEnumerator FadeIn()
    {
        blackFade.CrossFadeAlpha(0, fadeDuration, false); //turns off alpha
        yield return new WaitForSeconds(4.5f);
        fadeGO.SetActive(false);
    }

    void FadeOut()
    {
        blackFade.CrossFadeAlpha(2, fadeDuration, true); //turns on Alpha
    }

}
