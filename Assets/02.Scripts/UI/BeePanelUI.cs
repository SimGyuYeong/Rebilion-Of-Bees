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
    private Image _honeyTypeIcon;
    public int slot;
    private GameObject _notgetPanel;

    private Shop _shop;
    private Bee _bee;
    private BeeUpgrade _upgrade;

    public UnityEvent<Bee> InfoButtonClickEvent;

    private void Awake()
    {
        _nameText = transform.Find("name").GetComponent<TextMeshProUGUI>();
        _levelText = transform.Find("level").GetComponent<TextMeshProUGUI>();
        _priceText = transform.Find("Button/price").GetComponent<TextMeshProUGUI>();
        _damageText = transform.Find("Damage/Value").GetComponent<TextMeshProUGUI>();
        _buttonImage = transform.Find("Button").GetComponent<Image>();
        _icon = transform.Find("Icon").GetComponent<Image>();
        _honeyTypeIcon = transform.Find("HoneyType").GetComponent<Image>();
        _notgetPanel = transform.Find("NotGetPanel").gameObject;

        _shop = transform.parent.parent.parent.GetComponent<Shop>();
    }

    /// <summary>
    /// 패널 정보 업데이트
    /// </summary>
    /// <param name="bee"></param>
    /// <param name="upgrade"></param>
    public void Refresh(Bee bee, BeeUpgrade upgrade)
    {
        if(bee.data._itemGrade == 0)
        {
            _notgetPanel.SetActive(true);
            _bee = bee;
            _upgrade = upgrade;
        }
        else
        {
            _notgetPanel.SetActive(false);

            _nameText.text = bee.beeName;
            _levelText.text = string.Format($"Lv.{bee.data._itemGrade}");
            _priceText.text = upgrade.GetPrice().ToString();
            _damageText.text = bee.data._beeInfo._damage.ToString();
            _icon.sprite = bee.icon.sprite;
            _honeyTypeIcon.sprite = bee.honeyType;

            _buttonImage.color = upgrade.IsPurchase() ? Color.white : Color.gray;
            _bee = bee;
            _upgrade = upgrade;
        }
    }

    public void Refresh()
    {
        if (_bee.data._itemGrade == 0)
        {
            _notgetPanel.SetActive(true);
        }
        else
        {
            _notgetPanel.SetActive(false);

            _nameText.text = _bee.beeName;
            _levelText.text = string.Format($"Lv.{_bee.data._itemGrade}");
            _priceText.text = _upgrade.GetPrice().ToString();
            _damageText.text = _bee.data._beeInfo._damage.ToString();
            _icon.sprite = _bee.icon.sprite;
            _honeyTypeIcon.sprite = _bee.honeyType;

            _buttonImage.color = _upgrade.IsPurchase() ? Color.white : Color.gray;
        }
    }

    /// <summary>
    /// 구매
    /// </summary>
    public void Purchase()
    {
        _shop.Purchase(slot);
    }

    /// <summary>
    /// 패널 클릭시 벌 정보 띄우는 함수
    /// </summary>
    public void InfoButtonClick()
    {
        InfoButtonClickEvent?.Invoke(_bee);
    }
}
