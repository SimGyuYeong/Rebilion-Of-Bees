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
        
    }

    private void Start()
    {
        Invoke("Init", 0.1f);
    }

    public virtual void Init()
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
            GameManager.Instance._saveManager._userSave.USER_HASMONEY -= _itemList[slot].GetPrice();
            _itemList[slot].Upgrade();
        }
    }
}
