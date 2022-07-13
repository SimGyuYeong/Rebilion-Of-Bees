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
    [Header("½½·Ô¹øÈ£")]
    public int slot = 0;

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
        return GetPrice() <= GameManager.Instance._saveManager._userSave.USER_HASMONEY;
    }

    public void Upgrade()
    {
        if(IsPurchase())
        {
            GameManager.Instance._saveManager._userSave.USER_HASMONEY -= GetPrice();
            level++;
            upgradeType.Upgrade();
            panel.Refresh(this);
        }
    }
}
