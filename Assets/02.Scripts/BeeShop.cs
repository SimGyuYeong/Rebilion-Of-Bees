using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeShop : Shop
{
    public List<BeeUpgrade> beeList = new List<BeeUpgrade>();

    protected override void Init()
    {
        int _slot = 0;
        foreach (var bee in beeList)
        {
            _itemList.Add(bee);
            BeePanelUI panel = Instantiate(panelTemplate, _contentTrm);

            bee.panel = panel;
            bee.slot = _slot;
            bee.level = GameManager.Instance._saveManager._userSave.GetBeeLvList(_slot);
            bee.bee.isGet = true;
            if (bee.level == 0) bee.bee.isGet = false;
            bee.price = bee.GetPrice();

            panel.gameObject.SetActive(true);
            panel.slot = _slot;
            panel.Refresh(bee.bee, bee);
            _slot++;
        }
    }
}
