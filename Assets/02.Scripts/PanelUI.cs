using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class PanelUI : MonoBehaviour
{
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _levelText;
    private TextMeshProUGUI _priceText;
    private TextMeshProUGUI _damageText;
    private Image _buttonImage;
    private Image _icon;
    private int _slot;

    private Shop _shop;
    private Bee _bee;

    public UnityEvent<Bee> InfoButtonClickEvent;

    private void Awake()
    {
        _nameText = transform.Find("name").GetComponent<TextMeshProUGUI>();
        _levelText = transform.Find("level").GetComponent<TextMeshProUGUI>();
        _priceText = transform.Find("Button/price").GetComponent<TextMeshProUGUI>();
        _damageText = transform.Find("Damage/Value").GetComponent<TextMeshProUGUI>();
        _buttonImage = transform.Find("Button").GetComponent<Image>();
        _icon = transform.Find("Icon").GetComponent<Image>();

        _shop = transform.parent.parent.parent.GetComponent<Shop>();
    }

    public void Refresh(Bee bee, BeeUpgrade upgrade)
    {
        _nameText.text = bee.beeName;
        _levelText.text = string.Format($"Lv.{bee.level}");
        _priceText.text = upgrade.GetPrice().ToString();
        _damageText.text = bee.damage.ToString();
        _icon.sprite = bee.icon.sprite;
        _slot = upgrade.slot;
        
        _buttonImage.color = upgrade.IsPurchase() ? Color.white : Color.gray;
        _bee = bee;
    }

    public void Purchase()
    {
        _shop.Purchase(_slot);
    }

    public void InfoButtonClick()
    {
        InfoButtonClickEvent?.Invoke(_bee);
    }
}
