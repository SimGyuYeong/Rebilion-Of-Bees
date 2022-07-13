using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeType : MonoBehaviour
{
    public float addValue;
    public string info;

    /// <summary>
    /// 강화를 할 때 발동될 함수
    /// </summary>
    public abstract void Upgrade();
}
