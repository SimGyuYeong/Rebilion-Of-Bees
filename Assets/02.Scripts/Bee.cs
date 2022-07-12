using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    public string beeName; // 벌 이름
    public string honeyType; // 꿀 속성
    public long level; // 레벨
    public long damage; // 공격력
    public float attackSpeed; // 공격속도
    public float critical; // 크리티컬 확률
    public int honeyAmount; // 출장시 지급될 꿀량
    public string rangeType; // 공격 타입 ( 근거리,중거리,원거리 )
    public string info; // 설명
    public Image icon; // 아이콘

    public static void ApplyDamage(long damage)
    {
        foreach(var bee in FindObjectsOfType<Bee>())
        {
            bee.damage += damage;
        }
    }

    public void SpawnBee()
    {

    }
}
