using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenuFader : MonoBehaviour
{
    public GameObject warning;
    public TextMeshProUGUI warningTitle;
    public TextMeshProUGUI warningTxt;

    public Image blackFade;
    public GameObject fadeGO;
    public int fadeDuration;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInWithWarning());
    }

    IEnumerator FadeInWithWarning()
    {
        //epilepsy warning starts true 
        warning.SetActive(true);

        //warning image fades to 0 alpha   
        warningTxt.CrossFadeAlpha(0, 2, false);
        warningTitle.CrossFadeAlpha(0, 4, false);

        yield return new WaitForSeconds(3);
        warning.SetActive(false);

        //black fade image fades to 0 alpha
        blackFade.CrossFadeAlpha(0, fadeDuration, false);

        yield return new WaitForSeconds(3.5f);

        fadeGO.SetActive(false);
    }
}
