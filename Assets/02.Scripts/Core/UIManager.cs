using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Numerics;
using System;
using Vector3 = UnityEngine.Vector3;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel = null;

    public Transform topPanel;

    private TextMeshProUGUI _stageText;
    private TextMeshProUGUI _goldText;
    private TextMeshProUGUI _royalText;

    private int stage, money, royal;

    private void Awake()
    {
        _stageText = topPanel.Find("Stage").GetComponent<TextMeshProUGUI>();
        _goldText = topPanel.Find("Gold/Value").GetComponent<TextMeshProUGUI>();
        _royalText = topPanel.Find("Royal/Value").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        stage = 1;
        money = GameManager.Instance._saveManager._userSave.USER_HASMONEY;
        royal = 1;

        TopPanelUpdate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionPanelControl();
        }
    }

    public void TopPanelUpdate()
    {
        StageUpdate();
        GoldValueUpdate();
        RoyalValueUpdate();
    }

    public void StageUpdate()
    {
        string stagetext = stage.ToString();
        if (stage < 10) stagetext = "00" + stagetext;
        else if (stage < 100) stagetext = "0" + stagetext;
        _stageText.text = "Stage " + stagetext;
    }

    public void GoldValueUpdate()
    {
        _goldText.text = GetUnit(money);
        Sequence seq = DOTween.Sequence();
        seq.Append(_goldText.transform.DOScale(Vector3.one * 1.2f, .2f));
        seq.Append(_goldText.transform.DOScale(Vector3.one, .2f));
    }

    public void RoyalValueUpdate()
    {
        _royalText.text = GetUnit(royal);
        Sequence seq = DOTween.Sequence();
        seq.Append(_royalText.transform.DOScale(Vector3.one * 1.2f, .2f));
        seq.Append(_royalText.transform.DOScale(Vector3.one, .2f));
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

    public string GetUnit(long unit)
    {
        if (unit >= 1000)
        {
            int placeN = 3;
            BigInteger value = unit;
            List<int> numList = new List<int>();
            int p = (int)Mathf.Pow(10, placeN);
            do
            {
                numList.Add((int)(value % p));
                value /= p;
            }
            while (value >= 1);

            int num = numList.Count < 2 ? numList[0] : numList[numList.Count - 1] * p + numList[numList.Count - 2];
            double f = (num / (float)p);
            f = Math.Round(f, 3);
            return f.ToString() + " " + GetUnitText(numList.Count - 1);
        }
        else
        {
            return unit.ToString();
        }
    }

    private string GetUnitText(int index)
    {
        index--;
        if (index < 0) return "";
        int repeatCount = (index / 26) + 1;
        string retStr = "";
        for (int i = 0; i < repeatCount; i++) retStr += (char)(65 + index % 26);
        return retStr;
    }
}
