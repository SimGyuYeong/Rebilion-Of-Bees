using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Numerics;
using System;
using Vector3 = UnityEngine.Vector3;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject optionPanel = null;

    public Transform topPanel;

    private TextMeshProUGUI _stageText;
    private TextMeshProUGUI _goldText;
    private TextMeshProUGUI _royalText;

    public TextMeshProUGUI beeSpawnDelayText;
    public TextMeshProUGUI honeySpawnDelayText;

    public Sprite[] honeySpriteList;
    public Sprite eggSprite;

    private void Awake()
    {
        _stageText = topPanel.Find("Stage").GetComponent<TextMeshProUGUI>();
        _goldText = topPanel.Find("Gold/Value").GetComponent<TextMeshProUGUI>();
        _royalText = topPanel.Find("Royal/Value").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Invoke("TopPanelUpdate", 0.1f);
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
        BeeSpawnDelayCntUpdate();
        HoneySpawnDelayCntUpdate();
    }

    public void StageUpdate()
    {
        string stagetext = (GameManager.Instance._saveManager._userSave.USER_STAGE + 1).ToString();
        if (GameManager.Instance._saveManager._userSave.USER_STAGE < 10) stagetext = "00" + stagetext;
        else if (GameManager.Instance._saveManager._userSave.USER_STAGE < 100) stagetext = "0" + stagetext;
        _stageText.text = "Stage " + stagetext;
    }

    public void GoldValueUpdate()
    {
        _goldText.text = GetUnit(GameManager.Instance._saveManager._userSave.USER_HASMONEY);
        Sequence seq = DOTween.Sequence();
        seq.Append(_goldText.transform.DOScale(Vector3.one * 1.2f, .2f));
        seq.Append(_goldText.transform.DOScale(Vector3.one, .2f));
    }

    public void RoyalValueUpdate()
    {
        _royalText.text = GetUnit(GameManager.Instance._saveManager._userSave.USER_HASROYALJELLY);
        Sequence seq = DOTween.Sequence();
        seq.Append(_royalText.transform.DOScale(Vector3.one * 1.2f, .2f));
        seq.Append(_royalText.transform.DOScale(Vector3.one, .2f));
    }

    public void BeeSpawnDelayCntUpdate()
    {
        beeSpawnDelayText.text = String.Format($"{GameManager.Instance._saveManager._userSave.USER_CURRENTEGG} / {GameManager.Instance._saveManager._userSave.USER_MAXEGG}");
    }

    public void HoneySpawnDelayCntUpdate()
    {
        honeySpawnDelayText.text = String.Format($"{GameManager.Instance._saveManager._userSave.USER_CURRENTHONEY} / {GameManager.Instance._saveManager._userSave.USER_MAXHONEY}");
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
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
