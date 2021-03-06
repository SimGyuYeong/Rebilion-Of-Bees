using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeeUpgrade : IShopItem
{
    public Bee bee; // 벌 정보
    public BeePanelUI panel; // 패널 정보
    public int slot = 0; // 슬롯 번호
    public int defaultPrice = 0; // 기본 가격
    public int price = 0; // 현재 가격
    public int addDamage = 0; // 구매시 증가할 데미지

    public int GetPrice()
    {
        price = Mathf.RoundToInt(defaultPrice + ((defaultPrice * (bee.data._itemGrade - 1)) * 0.45f));

        return price;
    }

    public void Upgrade()
    {
        bee.data._itemGrade += 1;
        GameManager.Instance._saveManager._userSave.ChangeBeeInfo(slot, bee.data._itemGrade);
        Bee.ApplyDamage(addDamage, bee.beeName);
        panel.Refresh(bee, this);
    }

    public bool IsPurchase()
    {
        return GetPrice() <= GameManager.Instance._saveManager._userSave.USER_HASMONEY;
    }
}
