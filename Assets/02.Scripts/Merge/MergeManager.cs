using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeManager : MonoBehaviour
{
    public Button _beeBtn;
    public Button _honeyBtn;
    public ItemSave _eggInform;

    private void Start()
    {
        _beeBtn.GetComponent<Button>().onClick.AddListener(() => CreateBee());
        _honeyBtn.GetComponent<Button>().onClick.AddListener(() => CreateHoney());
        StartCoroutine(AddBeeCnt());
    }

    IEnumerator AddBeeCnt()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            GameManager.Instance._saveManager._userSave.USER_CURRENTEGG += 1;
            GameManager.Instance._saveManager._userSave.USER_CURRENTHONEY += 1;
        }
    }

    public void CreateBee()
    {
        // 알이 있는지?
        if (GameManager.Instance._saveManager._userSave.USER_CURRENTEGG <= 0) return;

        int index = -1;
        for (int i = 0; i < GameManager.Instance._slotList.Count; i++)
        {
            if (GameManager.Instance._slotList[i].transform.childCount == 0)
            {
                index = i;
                break;
            }
        }

        if (index == -1) return;

        ItemInform itemInform = new ItemInform
        {
            _itemName = _eggInform._itemName,
            _itemData = new ItemData
            {
                _itemType = _eggInform._itemType,
                _itemGrade = _eggInform._itemGrade,
                _slotNumber = index
            },
            _imageSprite = _eggInform._itemSprite
        };

        GameManager.Instance._saveManager._userSave.AddItemInfo(itemInform);
        GameManager.Instance._saveManager._userSave.USER_CURRENTEGG -= 1;
    }

    public void CreateHoney()
    {
        // 확률 넣어야 돼

        if (GameManager.Instance._saveManager._userSave.USER_CURRENTHONEY <= 0) return;

        int index = -1;
        for (int i = 0; i < GameManager.Instance._slotList.Count; i++)
        {
            if (GameManager.Instance._slotList[i].transform.childCount == 0)
            {
                index = i;
                break;
            }
        }

        if (index == -1) return;

        int itemIndex = 0;

        ItemInform itemInform = new ItemInform
        {
            _itemName = "",
            _itemData = new ItemData
            {
                _itemType = ItemType.HONEY,
                _itemGrade = itemIndex,
                _slotNumber = index
            },
            _imageSprite = UIManager.Instance.honeySpriteList[0]
        };

        GameManager.Instance._saveManager._userSave.AddItemInfo(itemInform);
        GameManager.Instance._saveManager._userSave.USER_CURRENTHONEY -= 1;
    }
}
