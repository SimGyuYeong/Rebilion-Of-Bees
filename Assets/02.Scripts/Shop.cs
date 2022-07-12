using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{ 
    protected List<IShopItem> _itemList = new List<IShopItem>();

    public BeePanelUI panelTemplate;
    protected Transform _contentTrm;

    private void Awake()
    {
        _contentTrm = transform.Find("Viewport/Content");
        Init();
    }

    protected virtual void Init()
    {
        //do nothing!
    }

    /// <summary>
    /// 구매함수
    /// </summary>
    /// <param name="slot"></param> 
    public void Purchase(int slot)
    {
        if (_itemList[slot].IsPurchase())
        {
            SaveManager.instance._userSave._hasMoney -= _itemList[slot].GetPrice();
            _itemList[slot].Upgrade();
        }
    }
}
