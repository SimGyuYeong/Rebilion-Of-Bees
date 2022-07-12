using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionPanelControl();
        }
    }

    public void OptionPanelControl()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);
        if (optionPanel.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
