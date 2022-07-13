using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopItem
{

    /// <summary>
    /// ���� ���ϴ� �Լ�
    /// </summary>
    /// <returns></returns>
    public int GetPrice();

    /// <summary>
    /// ���Ű� �������� ���ϴ� �Լ�
    /// </summary>
    /// <returns></returns>
    public bool IsPurchase();

    /// <summary>
    /// ���׷��̵� �Լ�
    /// </summary>
    public void Upgrade();
}
