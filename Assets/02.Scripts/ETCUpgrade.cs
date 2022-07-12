using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETCUpgrade : MonoBehaviour, IShopItem
{
    public UpgradeType upgradeType;
    public UpgradePanelUI panel;
    public long defaultPrice = 0;
    public long price = 0;
    public long level = 0;

    private void Awake()
    {
        upgradeType = GetComponent<UpgradeType>();
        panel = GetComponent<UpgradePanelUI>();
    }

    public long GetPrice()
    {
        price = defaultPrice + level * 10;
        return price;
    }

    public bool IsPurchase()
    {
        return true;
    }

    public void Upgrade()
    {
        if(IsPurchase())
        {
            level++;
            upgradeType.Upgrade();
            panel.Refresh(this);
        }
    }
}
