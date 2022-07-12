using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        if (optionPanel.transform.localScale == Vector3.zero)
        {
            optionPanel.transform.DOScale(Vector3.one, .3f).SetUpdate(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            optionPanel.transform.DOScale(Vector3.zero, .3f).SetUpdate(true);
        }
    }
}
