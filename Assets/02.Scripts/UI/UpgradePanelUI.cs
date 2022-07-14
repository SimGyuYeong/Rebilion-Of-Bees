using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradePanelUI : MonoBehaviour
{
    private TextMeshProUGUI _priceText;
    private TextMeshProUGUI _infoText;
    private Image _buttonImage;

    private ETCUpgrade _upgrade;

    private void Awake()
    {
        _priceText = transform.Find("Button/price").GetComponent<TextMeshProUGUI>();
        _infoText = transform.Find("info").GetComponent<TextMeshProUGUI>();
        _buttonImage = transform.Find("Button").GetComponent<Image>();
    }

    public void Refresh(ETCUpgrade upgrade)
    {
        _priceText.text = UIManager.Instance.GetUnit(upgrade.GetPrice());

        string[] info = upgrade.upgradeType.info.Split("{}");
        _infoText.text = string.Format($"{info[0]} {upgrade.level * upgrade.upgradeType.addValue}{info[1]}");

        _buttonImage.color = upgrade.IsPurchase() ? Color.white : Color.gray;
    }
}
