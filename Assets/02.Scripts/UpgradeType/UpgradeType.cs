using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeType : MonoBehaviour
{
    public float addValue;
    public string info;

    /// <summary>
    /// ��ȭ�� �� �� �ߵ��� �Լ�
    /// </summary>
    public abstract void Upgrade();
}
