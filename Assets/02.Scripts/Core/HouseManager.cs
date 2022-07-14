using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoSingleton<HouseManager>
{
    public int health = 500;

    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            GameManager.Instance._saveManager._userSave.ResetData();
            LoadScenes.Instance.LoadScene("TitleScene");
        }
    }
}
