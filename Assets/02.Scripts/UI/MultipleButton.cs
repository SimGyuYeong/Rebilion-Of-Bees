using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleButton : MonoBehaviour
{
    public GameObject[] panelList;
    public Image[] buttonImageList;
    private int _selectedPanelSlot;
    public int defaultSlot;

    private void Awake()
    {
        _selectedPanelSlot = defaultSlot;
        panelList[_selectedPanelSlot].SetActive(true);
        buttonImageList[_selectedPanelSlot].color = Color.gray;
    }

    public void SelectPanel(int slot)
    {
        if(_selectedPanelSlot != slot)
        {
            panelList[_selectedPanelSlot].SetActive(false);
            panelList[slot].SetActive(true);

            buttonImageList[_selectedPanelSlot].color = Color.white;
            buttonImageList[slot].color = Color.gray;

            _selectedPanelSlot = slot;
        }
    }
}
