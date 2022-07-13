using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeeUpgrade : IShopItem
{
    public Bee bee; // 벌 정보
    public BeePanelUI panel; // 패널 정보
    public int slot = 0; // 슬롯 번호
    public long defaultPrice = 0; // 기본 가격
    public long price = 0; // 현재 가격
    public long level = 0; // 레벨
    public long addDamage = 0; // 구매시 증가할 데미지

    public long GetPrice()
    {
        if(level != bee.level)
        {
            price = defaultPrice + (bee.level - 1) * 10;
            level = bee.level;
        }

        return price;
    }

    public void Upgrade()
    {
        bee.level += 1;
        Bee.ApplyDamage(addDamage, bee.beeName);
        panel.Refresh(bee, this);
    }

    public bool IsPurchase()
    {
        return GetPrice() <= 1;
    }
}
