using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : PoolableMono
{
    public ItemSave data;

    public string beeName; // 벌 이름
    public Sprite honeyType; // 꿀 속성
    public int level; // 레벨
    public string info; // 설명
    public Image icon; // 아이콘
    public Sprite bulletSprite; // 총알 이미지

    private bool _isAttack = false;
    private Transform _targetTrm;
     
    public enum RangeType
    { 
        Short = 3,
        Middle = 6,
        Long = 10
    }

    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    public Bee GetBee()
    {
        return this;
    }
    
    public void DataReset(Bee bee)
    {
        beeName = bee.name;
        honeyType = bee.honeyType;
        level = bee.level;
        info = bee.info;
        icon = bee.icon;
        bulletSprite = bee.bulletSprite;
        data = bee.data;

        _circleCollider.radius = data._beeInfo._range == RangeType.Short ? 0.5f : data._beeInfo._range == RangeType.Middle ? 1f : 1.5f;
    }

    public static void ApplyDamage(int damage, string beeName)
    {
        foreach(var bee in FindObjectsOfType<Bee>())
        {
            if(bee.beeName == beeName) bee.data._beeInfo._damage += damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Monster" && _isAttack == false)
        {
            Attack(collision.transform);
            StartCoroutine(AttackDelayCoroutine());
        }
    }

    public void Attack(Transform monsterTrm)
    {
        _isAttack = true;

        Bullet bullet = PoolManager.Instance.Pop("Bullet") as Bullet;
        bullet.Init(bulletSprite, monsterTrm, transform.position);
        bullet.Shoot(Damaged);
        _targetTrm = monsterTrm;
    }

    public void Damaged()
    {
        float _damage = data._beeInfo._damage;
        _damage += _damage * (GameManager.Instance._saveManager._userSave.USER_SHOPITEMLVLIST[0] * 2f);
        int random = Random.Range(0, 100);
        bool cri = false;
        if(random < data._beeInfo._critical)
        {
            cri = true;
            _damage *= 2;
        }
        _targetTrm.GetComponent<Monster>().Damaged(Mathf.RoundToInt(_damage), cri);
    }

    IEnumerator AttackDelayCoroutine()
    {
        float ime = 2.3f - 2 * data._beeInfo._attackSpeed;
        yield return new WaitForSeconds(ime);
        _isAttack = false;
    }

    public void Travle()
    {
        float price = data._beeInfo._honeyAmount;
        price += price * GameManager.Instance.travelAddPercent;
        GameManager.Instance._saveManager._userSave.USER_CURRENTHONEY += Mathf.RoundToInt(price);
    }

    public override void Reset()
    {
        _isAttack = false;
    }
}
