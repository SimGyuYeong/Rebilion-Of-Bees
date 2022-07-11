using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeShop : Shop
{
    public List<BeeUpgrade> beeList = new List<BeeUpgrade> ();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(beeList[0].bee, transform);
        }
    }

    protected override void Init()
    {
        int _slot = 0;
        foreach(var bee in beeList)
        {
            _itemList.Add(bee);
            PanelUI panel = Instantiate(panelTemplate, _contentTrm);
            panel.gameObject.SetActive(true);
            panel.Refresh(bee.bee, bee);

            bee.panel = panel;
            bee.slot = _slot;
            bee.level = 1;
            bee.price = bee.GetPrice();
            _slot++;
        }
    }
}
