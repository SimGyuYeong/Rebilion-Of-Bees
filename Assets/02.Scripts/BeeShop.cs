using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeShop : Shop
{
    public List<BeeUpgrade> beeList = new List<BeeUpgrade>();

    private void OnEnable()
    {
        BeePanelUI[] panel = transform.GetComponentsInChildren<BeePanelUI>();
        foreach(var p in panel)
        {
            p.Refresh();
        }
    }

    public override void Init()
    {
        int _slot = 0;
        foreach (var bee in beeList)
        {
            _itemList.Add(bee);
            BeePanelUI panel = Instantiate(panelTemplate, _contentTrm);

            bee.panel = panel;
            bee.slot = _slot;
            bee.price = bee.GetPrice();

            panel.gameObject.SetActive(true);
            panel.slot = _slot;
            panel.Refresh(bee.bee, bee);
            _slot++;
        }
    }
}
