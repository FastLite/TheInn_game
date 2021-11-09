using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fader : MonoBehaviour
{
    public Image blackFade;
    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(1.0f); //Canvas alpha starts on
        FadeIn();
    }

    void FadeIn()
    {
        blackFade.CrossFadeAlpha(0, 2, false); //turns off alpha
    }

    void FadeOut()
    {
        blackFade.CrossFadeAlpha(2, 0, true); //turns on Alpha
    }
}
