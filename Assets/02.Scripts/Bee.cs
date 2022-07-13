using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    public string beeName; // 벌 이름
    public Sprite honeyType; // 꿀 속성
    public int level; // 레벨
    public int damage; // 공격력
    public float attackSpeed; // 공격속도
    public float critical; // 크리티컬 확률
    public int honeyAmount; // 출장시 지급될 꿀량
    public string rangeType; // 공격 타입 ( 근거리,중거리,원거리 )
    public string info; // 설명
    public bool isGet; // 해당 벌을 얻었는가?
    public Image icon; // 아이콘

    private TravelPrice travel;

    private void Awake()
    {
        travel = FindObjectOfType<TravelPrice>();
    }

    public static void ApplyDamage(int damage, string beeName)
    {
        foreach(var bee in FindObjectsOfType<Bee>())
        {
            if(bee.beeName == beeName) bee.damage += damage;
        }
    }

    public void Travle()
    {
        float price = GameManager.Instance._saveManager._userSave.USER_CURRENTHONEY;
        price += price * travel.travelAddPercent;
        honeyAmount += Mathf.RoundToInt(price);
        Destroy(this);
    }
}
