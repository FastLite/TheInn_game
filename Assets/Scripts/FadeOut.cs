using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeOut : MonoBehaviour
{
    public Image blackFade;
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(1.0f); //Canvas alpha starts on
        FadeIn();
    }

    // Update is called once per frame
    void FadeIn()
    {
        blackFade.CrossFadeAlpha(0, 2, false); //turns off alpha
    }
}
