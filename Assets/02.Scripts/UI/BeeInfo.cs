using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening; 

public class BeeInfo : MonoBehaviour
{
    private Image _honeyTypeIcon;
    private TextMeshProUGUI _nameText;
    private Image _beeImage;
    private TextMeshProUGUI _levelText;
    private TextMeshProUGUI _infoText;
    private TextMeshProUGUI _damageText;
    private TextMeshProUGUI _criticalText;
    private TextMeshProUGUI _attackSpeedText;
    private TextMeshProUGUI _rangeTypeText;
    private Image _honeyTypeImage;
    private TextMeshProUGUI _honeyAmountText;

    private void Awake()
    {
        _honeyTypeIcon = transform.Find("NamePanel/Image").GetComponent<Image>();
        _nameText = transform.Find("NamePanel/name").GetComponent<TextMeshProUGUI>();
        _beeImage = transform.Find("BeeImage").GetComponent<Image>();
        _levelText = transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
        _infoText = transform.Find("InfoText").GetComponent<TextMeshProUGUI>();

        _damageText = transform.Find("InfoPanel/Attack/value").GetComponent<TextMeshProUGUI>();
        _criticalText = transform.Find("InfoPanel/Critical/value").GetComponent<TextMeshProUGUI>();
        _attackSpeedText = transform.Find("InfoPanel/AttackSpeed/value").GetComponent<TextMeshProUGUI>();
        _rangeTypeText = transform.Find("InfoPanel/RangeType/value").GetComponent<TextMeshProUGUI>();
        _honeyAmountText = transform.Find("InfoPanel/HoneyAmount/value").GetComponent<TextMeshProUGUI>();
        _honeyTypeImage = transform.Find("InfoPanel/HoneyType/value").GetComponent<Image>();
    }

    /// <summary>
    /// ¹ú Á¤º¸Ã¢ Å°°í ²ô´Â ÇÔ¼ö
    /// </summary>
    /// <param name="bee"></param>
    public void ShowBeeInfoUI(Bee bee = null)
    {
        if(transform.localScale == Vector3.zero)
        {
            transform.DOScale(Vector3.one, .3f);
            _nameText.text = bee.beeName;
            _beeImage.sprite = bee.icon.sprite;
            _levelText.text = bee.level.ToString();
            _infoText.text = bee.info;
            _damageText.text = bee.damage.ToString();
            _criticalText.text = bee.critical.ToString();
            _attackSpeedText.text = bee.attackSpeed.ToString();
            _rangeTypeText.text = bee.rangeType;
            _honeyAmountText.text = bee.honeyAmount.ToString();
        }
    }

    public void CloseBeeInfoUI()
    {
        transform.DOScale(Vector3.zero, .3f);
    }
}
