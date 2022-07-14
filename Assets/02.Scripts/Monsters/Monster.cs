using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : PoolableMono
{
    public string monsterName;
    public int health;
    public float moveSpd;
    public int damage;
    public int gold;

    private int _defaultHp;
    private float _defaultSpd;

    private MonsterMove _move;
    private Animator _animator;
    private CircleCollider2D _collider2D;

    public Monster(string monsterName, int health, float moveSpd, int damage, int gold)
    {
        this.monsterName = monsterName;
        this.health = health;
        this.moveSpd = moveSpd;
        this.damage = damage;
        this.gold = gold;
        _move._speed = moveSpd;

        _defaultHp = health;
        _defaultSpd = moveSpd;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Damaged(1);
        }
    }

    private void Awake()
    {
        _move = GetComponent<MonsterMove>();
        _animator = GetComponent<Animator>();
    }

    public void Damaged(int damage)
    {
        _animator.SetTrigger("Hit");

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
        moveSpd = 0;
        _collider2D.enabled = false;
        GameManager.Instance._saveManager._userSave.USER_HASMONEY += gold;
        StartCoroutine(DieCoroutine());
    }

    IEnumerator DieCoroutine()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.DOFade(0, .5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }


    public override void Reset()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.DOFade(1, 0);
        _collider2D.enabled = true;

        health = _defaultHp;
        moveSpd = _defaultSpd;
    }
}
