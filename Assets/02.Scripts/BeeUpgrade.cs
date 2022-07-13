using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeeUpgrade : IShopItem
{
    public Bee bee; // �� ����
    public BeePanelUI panel; // �г� ����
    public int slot = 0; // ���� ��ȣ
    public int defaultPrice = 0; // �⺻ ����
    public int price = 0; // ���� ����
    public int level = 0; // ����
    public int addDamage = 0; // ���Ž� ������ ������

    public int GetPrice()
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
        GameManager.Instance._saveManager._userSave.ChangeBeeInfo(slot, bee.level);
        Bee.ApplyDamage(addDamage, bee.beeName);
        panel.Refresh(bee, this);
    }

    public bool IsPurchase()
    {
        return GetPrice() <= GameManager.Instance._saveManager._userSave.USER_HASMONEY;
    }
}
