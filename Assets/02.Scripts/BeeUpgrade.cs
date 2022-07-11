using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeeUpgrade : IShopItem
{
    public Bee bee; // �� ����
    public PanelUI panel; // �г� ����
    public int slot = 0; // ���� ��ȣ
    public long price = 0; // ����
    public long level = 0; // ����
    public long addDamage = 0; // ���Ž� ������ ������

    public long GetPrice()
    {
        if(level != bee.level)
        {
            price = bee.level * 10;
            level = bee.level;
        }

        return price;
    }

    public void Upgrade()
    {
        bee.level += 1;
        Bee.ApplyDamage(addDamage);
        panel.Refresh(bee, this);
    }

    public bool IsPurchase()
    {
        return GetPrice() <= SaveManager.instance._userSave._hasMoney;
    }
}
