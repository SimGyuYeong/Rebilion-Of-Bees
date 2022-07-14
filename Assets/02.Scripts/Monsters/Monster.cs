using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public string monsterName;
    public int health;
    public float moveSpd;
    public int damage;
    public int gold;

    private MonsterMove move;

    public Monster(string monsterName, int health, float moveSpd, int damage, int gold)
    {
        this.monsterName = monsterName;
        this.health = health;
        this.moveSpd = moveSpd;
        this.damage = damage;
        this.gold = gold;
        move._speed = moveSpd;
    }

    private void Awake()
    {
        move = GetComponent<MonsterMove>();
    }

    public void Damaged(int damage)
    {
        health -= damage;
        DamagePopup popup = PoolManager.Instance.Pop("DamagePopup") as DamagePopup; 
        popup?.Setup(damage, transform.position + new Vector3(0, 0.5f, 0), false, Color.black);
        if (health <= 0)
        {
            Dead();       
        }
    }

    /// <summary>
    /// 몬스터 사망 함수
    /// </summary>
    public void Dead()
    {
        GameManager.Instance._saveManager._userSave.USER_HASMONEY += gold;
        Destroy(gameObject);
    }
}
