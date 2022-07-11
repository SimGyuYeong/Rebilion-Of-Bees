using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelUI : MonoBehaviour
{
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _levelText;
    private TextMeshProUGUI _priceText;
    private TextMeshProUGUI _damageText;
    private Image _icon;
    private int _slot;

    private Shop _shop;

    private void Awake()
    {
        _nameText = transform.Find("name").GetComponent<TextMeshProUGUI>();
        _levelText = transform.Find("level").GetComponent<TextMeshProUGUI>();
        _priceText = transform.Find("Button/price").GetComponent<TextMeshProUGUI>();
        _damageText = transform.Find("damage").GetComponent<TextMeshProUGUI>();
        _icon = transform.Find("Icon").GetComponent<Image>();

        _shop = transform.parent.parent.parent.GetComponent<Shop>();
    }

    public void Refresh(Bee bee, BeeUpgrade upgrade)
    {
        _nameText.text = bee.beeName;
        _levelText.text = bee.level.ToString();
        _priceText.text = upgrade.price.ToString();
        _damageText.text = bee.damage.ToString();
        _icon.sprite = bee.icon.sprite;
        _slot = upgrade.slot;
    }

    public void Purchase()
    {
        _shop.Purchase(_slot);
    }
}
