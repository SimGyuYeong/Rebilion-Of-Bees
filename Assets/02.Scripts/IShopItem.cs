using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopItem
{

    /// <summary>
    /// 가격 구하는 함수
    /// </summary>
    /// <returns></returns>
    public int GetPrice();

    /// <summary>
    /// 구매가 가능한지 구하는 함수
    /// </summary>
    /// <returns></returns>
    public bool IsPurchase();

    /// <summary>
    /// 업그레이드 함수
    /// </summary>
    public void Upgrade();
}
