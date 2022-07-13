using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelPrice : UpgradeType
{
    public float travelAddPercent;
    
    private void Awake()
    {
        travelAddPercent = GameManager.Instance._saveManager._userSave.GetShopItemLvList(9) * addValue;
    }

    public override void Upgrade()
    {

    }
}
