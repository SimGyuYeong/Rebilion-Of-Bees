using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class BeePanelUI : MonoBehaviour
{
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _levelText;
    private TextMeshProUGUI _priceText;
    private TextMeshProUGUI _damageText;
    private Image _buttonImage;
    private Image _icon;
    public int slot;
    private GameObject _notgetPanel;

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
        _notgetPanel = transform.Find("NotGetPanel").gameObject;

        _shop = transform.parent.parent.parent.GetComponent<Shop>();
    }

    /// <summary>
    /// �г� ���� ������Ʈ
    /// </summary>
    /// <param name="bee"></param>
    /// <param name="upgrade"></param>
    public void Refresh(Bee bee, BeeUpgrade upgrade)
    {
        if(bee.isGet == false)
        {
            _notgetPanel.SetActive(true);
        }
        else
        {
            _notgetPanel.SetActive(false);

            _nameText.text = bee.beeName;
            _levelText.text = string.Format($"Lv.{bee.level}");
            _priceText.text = upgrade.GetPrice().ToString();
            _damageText.text = bee.damage.ToString();
            _icon.sprite = bee.icon.sprite;

            _buttonImage.color = upgrade.IsPurchase() ? Color.white : Color.gray;
            _bee = bee;
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    public void Purchase()
    {
        _shop.Purchase(slot);
    }

    /// <summary>
    /// �г� Ŭ���� �� ���� ���� �Լ�
    /// </summary>
    public void InfoButtonClick()
    {
        InfoButtonClickEvent?.Invoke(_bee);
    }
}
