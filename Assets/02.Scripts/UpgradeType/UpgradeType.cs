using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeType : MonoBehaviour
{
    public float addValue;
    public string info;
 
    public abstract void Upgrade();
}
