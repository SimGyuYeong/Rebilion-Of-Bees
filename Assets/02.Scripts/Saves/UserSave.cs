using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserSave
{
    public string USER_NAME
    {
        get => _userName;
        set
        {
            _userName = value;
            GameManager.Instance._saveManager.SaveUserName(_userName);
        }
    }
    public int USER_HASMONEY
    {
        get => _hasMoney;
        set
        {
            _hasMoney = value;
            GameManager.Instance._saveManager.SaveHasMoney(_hasMoney);
            UIManager.Instance.GoldValueUpdate();
        }
    }
    public int USER_HASROYALJELLY
    {
        get => _hasRoyalJelly;
        set
        {
            _hasRoyalJelly = value;
            GameManager.Instance._saveManager.SaveHasMoney(_hasRoyalJelly);
            UIManager.Instance.RoyalValueUpdate();
        }
    }
    public int USER_CURRENTHONEY
    {
        get => _currentHoney;
        set
        {
            _currentHoney = value;
            GameManager.Instance._saveManager.SaveCurrentHoney(_currentHoney);
            UIManager.Instance.HoneySpawnDelayCntUpdate();
        }
    }
    public int USER_MAXHONEY
    {
        get => _maxHoney;
        set
        {
            _maxHoney = value;
            GameManager.Instance._saveManager.SaveMaxHoney(_maxHoney);
            UIManager.Instance.HoneySpawnDelayCntUpdate();
        }
    }
    public int USER_CURRENTEGG
    {
        get => _currentEgg;
        set
        {
            _currentEgg = value;
            GameManager.Instance._saveManager.SaveCurrentEgg(_currentEgg);
            UIManager.Instance.BeeSpawnDelayCntUpdate();
        }
    }
    public int USER_MAXEGG
    {
        get => _maxEgg;
        set
        {
            _maxEgg = value;
            GameManager.Instance._saveManager.SaveMaxEgg(_maxEgg);
            UIManager.Instance.BeeSpawnDelayCntUpdate();
        }
    }
    public int USER_MAXBEECOUNT
    {
        get => _maxBeeCount;
        set
        {
            _maxBeeCount = value;
            GameManager.Instance._saveManager.SaveMaxBeeCount(_maxBeeCount);
        }
    }

    // 유저의 이름
    [SerializeField] private string _userName;

    [SerializeField] private int _hasMoney;
    [SerializeField] private int _hasRoyalJelly;

    // 꿀 정보
    [SerializeField] private int _currentHoney;
    [SerializeField] private int _maxHoney;

    // 알 정보
    [SerializeField] private int _currentEgg;
    [SerializeField] private int _maxEgg;

    [SerializeField] private int _maxBeeCount;


    [SerializeField] private List<ItemData> _towerDataList = new List<ItemData>();
    public void AddTowerInfo(TowerInform inform)
    {
        ItemData towerData = inform.towerData;
        _towerDataList.Add(towerData);
        CreateTower(towerData, inform.transform.parent.GetComponent<MapInform>()._mapNumber);

        GameManager.Instance._saveManager.SaveTowerInfos(_towerDataList);
    }
    public void RemoveTowerInfo(TowerInform inform)
    {
        ItemData towerData = inform.towerData;
        _towerDataList.Remove(towerData);

        GameManager.Instance._saveManager.SaveTowerInfos(_towerDataList);

        RemoveTower(towerData);
    }
    public void RefreshTowerInfo(ItemData inform)
    {
        GameManager.Instance._towerManager.RefreshTower(inform);
        CreateTower(inform, inform._slotNumber);
        
    }
    public Dictionary<int, GameObject> _towerDictionary = new Dictionary<int, GameObject>();
    public void CreateTower(ItemData inform, int index)
    {
        inform._slotNumber = index;
        int towerIndex = inform._slotNumber;
        GameObject obj = GameManager.Instance._towerManager.CreateTower(towerIndex, inform);
        _towerDictionary.Add(towerIndex, obj);
    }
    public void RemoveTower(ItemData inform)
    {
        int towerIndex = inform._slotNumber;
        GameObject tower = null;
        _towerDictionary.TryGetValue(towerIndex, out tower);
        if (tower != null)
        {
            GameManager.Instance._towerManager.RemoveTower(tower);
            _towerDictionary.Remove(towerIndex);
        }
    }

    [SerializeField] private List<ItemData> _itemDataList = new List<ItemData>();
    public List<ItemData> USER_ITEMDATALIST
    {
        get => _itemDataList;
    }

    public void AddItemInfo(ItemInform inform)
    {
        ItemData itemData = inform._itemData;
        _itemDataList.Add(itemData);

        CreateItem(inform);
        GameManager.Instance._saveManager.SaveItemInfos(_itemDataList);
    }
    public void RemoveItemInfo(ItemInform inform)
    {
        ItemData itemData = inform._itemData;
        _itemDataList.Remove(itemData);

        GameManager.Instance._saveManager.SaveItemInfos(_itemDataList);
    }
    public void RefreshItemInfo(ItemData inform)
    {
        ItemInform item = new ItemInform
        {
            _itemName = "",
            _itemData = inform,
            _imageSprite = inform._itemType == ItemType.HONEY ? UIManager.Instance.honeySpriteList[inform._itemGrade] :
            inform._itemType == ItemType.BEE ? GameManager.Instance.beeList[inform._itemGrade].icon.sprite : UIManager.Instance.eggSprite,
        };

        CreateItem(item);
    }
    public void RefreshItemInfo(ItemInform inform)
    {
        _itemDataList.Add(inform._itemData);
        inform._image.sprite = inform._imageSprite;
        GameManager.Instance._saveManager.SaveItemInfos(_itemDataList);
    }
    public void CreateItem(ItemInform inform)
    {
        int itemIndex = inform._itemData._slotNumber;
        GameObject obj = GameManager.Instance._itemManager.CreateItem(itemIndex);
        obj.GetComponent<ItemInform>().SetItemInform(inform);

        GameManager.Instance._saveManager.SaveItemInfos(_itemDataList);
    }

    public void DeleteItem(GameObject obj)
    {
        _itemDataList.Remove(obj.GetComponent<ItemInform>()._itemData);
        MonoBehaviour.Destroy(obj);
        GameManager.Instance._saveManager.SaveItemInfos(_itemDataList);
    }


    [SerializeField] private List<int> _beeLvList = new List<int>();
    public void ChangeBeeInfo(int index, int value)
    {
        _beeLvList[index] = value;
        GameManager.Instance._saveManager.SaveBeeInfos(_beeLvList);
    }
    public List<int> USER_BEELVLIST
    {
        get => _beeLvList;
    }

    [SerializeField] private List<int> _shopItemLvList = new List<int>();

    public void ChangeShopItemInfo(int index, int value)
    {
        _shopItemLvList[index] = value;
        GameManager.Instance._saveManager.SaveShopItemInfos(_shopItemLvList);
    }

    public List<int> USER_SHOPITEMLVLIST
    {
        get => _shopItemLvList;
    }

    /// <summary>
    /// 올라가 있는 포탑의 수를 체크하여 벌을 더 할 수 있는지?
    /// </summary>
    /// <returns></returns>
    public bool IsCanBuildBee()
    {
        if (_towerDataList.Count < _maxBeeCount) return true;

        return false;
    }

    public void ResetData()
    {
        USER_NAME = "";
        USER_HASMONEY = 0;
        USER_CURRENTHONEY = 0;
        USER_MAXHONEY = 10;
        USER_CURRENTEGG = 0;
        USER_MAXEGG = 10;
        USER_MAXBEECOUNT = 5;

        PlayerPrefs.DeleteKey("TowerInfoJsonStr");
        PlayerPrefs.DeleteKey("ItemInfoJsonStr");
        PlayerPrefs.DeleteKey("BeeInfoJsonStr");
        PlayerPrefs.DeleteKey("ShopItemJsonStr");

        _towerDataList.Clear();
        GameManager.Instance._saveManager.SaveTowerInfos(_towerDataList);

        _itemDataList.Clear();
        GameManager.Instance._saveManager.SaveItemInfos(_itemDataList);

        _beeLvList.Clear();
        _beeLvList.Add(1);
        for (int i = 0; i < 9; i++)
        {
            _beeLvList.Add(0);
        }
        GameManager.Instance._saveManager.SaveBeeInfos(_beeLvList);

        _shopItemLvList.Clear();
        for (int i = 0; i < 13; i++)
        {
            _shopItemLvList.Add(0);
        }
        GameManager.Instance._saveManager.SaveShopItemInfos(_shopItemLvList);
    }

    public UserSave() { }

    public UserSave(string userName, int hasMoney, int currentHoney, int maxHoney, int currentEgg, int maxEgg, int maxBee, List<ItemData> towerInfos, List<ItemData> itemInfos, List<int> beeInfos, List<int> shopItemInfos)
    {
        _userName = userName;
        _hasMoney = hasMoney;
        _currentHoney = currentHoney;
        _maxHoney = maxHoney;
        _currentEgg = currentEgg;
        _maxEgg = maxEgg;
        _maxBeeCount = maxBee;

        _towerDataList = towerInfos;
        if (_towerDataList == null)
        {
            _towerDataList = new List<ItemData>();
        }
        else
        {
            // 타워 초기 생성
            for (int i = 0; i < _towerDataList.Count; i++)
                RefreshTowerInfo(_towerDataList[i]);
        }

        _itemDataList = itemInfos;
        if (_itemDataList == null)
        {
            _itemDataList = new List<ItemData>();
        }
        else
        {
            // 아이템 초기 생성
            for (int i = 0; i < _itemDataList.Count; i++)
                RefreshItemInfo(_itemDataList[i]);
        }


        _beeLvList = beeInfos;
        if (_beeLvList == null)
        {
            _beeLvList = new List<int>();
        }
        else
        {
            int slot = 0;
            foreach(var bee in GameManager.Instance.beeList)
            {
                GameManager.Instance.itemSaveList[slot]._itemGrade = _beeLvList[slot];
                bee.data = GameManager.Instance.itemSaveList[slot];
                slot++;
            }
        }

        _shopItemLvList = shopItemInfos;
        if (_shopItemLvList == null)
        {
            _shopItemLvList = new List<int>();
        }

        UIManager.Instance.TopPanelUpdate();
        UIManager.Instance.BeeSpawnDelayCntUpdate();
        UIManager.Instance.HoneySpawnDelayCntUpdate();
        UIManager.Instance.GoldValueUpdate();
        UIManager.Instance.RoyalValueUpdate();
    }
}
