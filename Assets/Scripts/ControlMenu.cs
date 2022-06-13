using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlMenu : MonoBehaviour
{
    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;

    public void MenuEventChoice(GameObject highlightedUIOption)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(highlightedUIOption);
        Debug.Log(EventSystem.current.gameObject);
    }
}
    
