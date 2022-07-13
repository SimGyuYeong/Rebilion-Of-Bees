using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETCUpgrade : MonoBehaviour, IShopItem
{
    public UpgradeType upgradeType;
    public UpgradePanelUI panel;
    public int defaultPrice = 0;
    public int price = 0;
    public int level = 0;

    public enum PriceType
    {
        Money,
        Royal
    }

    [Header("½½·Ô¹øÈ£")]
    public int slot = 0;
    public PriceType priceType = PriceType.Money;

    private void Awake()
    {
        upgradeType = GetComponent<UpgradeType>();
        panel = GetComponent<UpgradePanelUI>();
    }

    private void Start()
    {
        level = GameManager.Instance._saveManager._userSave.GetShopItemLvList(slot);
        panel.Refresh(this);
    }

    public int GetPrice()
    {
        price = defaultPrice + level * 10;
        return price;
    }

    public bool IsPurchase()
    {
        if (priceType == PriceType.Money)
            return GetPrice() <= GameManager.Instance._saveManager._userSave.USER_HASMONEY;
        else
            return GetPrice() <= GameManager.Instance._saveManager._userSave.USER_HASMONEY;
    }

    public void Upgrade()
    {
        if (IsPurchase())
        {
            if (priceType == PriceType.Money)
                GameManager.Instance._saveManager._userSave.USER_HASMONEY -= GetPrice();
            else
                GameManager.Instance._saveManager._userSave.USER_HASMONEY -= GetPrice();

            level++;
            GameManager.Instance._saveManager._userSave.ChangeShopItemInfo(slot, level);
            upgradeType.Upgrade();
            panel.Refresh(this);
        }
    }
}
