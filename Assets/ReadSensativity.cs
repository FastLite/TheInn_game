using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadSensativity : MonoBehaviour
{
    public Slider slider;
    public TMP_Text tm;
    public bool volume;

    private void Update()
    {
        if (volume)
        {
            tm.text = (slider.value*100 + "%");

        }
        else
        {
            
            tm.text = Mathf.RoundToInt(slider.value).ToString();

        }
        

    }
}
