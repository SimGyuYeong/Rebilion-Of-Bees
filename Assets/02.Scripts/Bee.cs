using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : PoolableMono
{
    public string beeName; // �� �̸�
    public Sprite honeyType; // �� �Ӽ�
    public int level; // ����
    public int damage; // ���ݷ�
    public float attackSpeed; // ���ݼӵ�
    public float critical; // ũ��Ƽ�� Ȯ��
    public int honeyAmount; // ����� ���޵� �ܷ�
    public RangeType rangeType; // ���� Ÿ�� ( �ٰŸ�,�߰Ÿ�,���Ÿ� )
    public string info; // ����
    public bool isGet; // �ش� ���� ����°�?
    public Image icon; // ������
    public Sprite bulletSprite; // �Ѿ� �̹���

    private bool _isAttack = false;
    private Bullet _bullet;
     
    public enum RangeType
    { 
        Short = 150,
        Middle = 225,
        Long = 300
    }

    private TravelPrice travel;
    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        travel = FindObjectOfType<TravelPrice>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _circleCollider.radius = (int)rangeType;
    }

    public static void ApplyDamage(int damage, string beeName)
    {
        foreach(var bee in FindObjectsOfType<Bee>())
        {
            if(bee.beeName == beeName) bee.damage += damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
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
        _bullet = bullet;
    }

    public void Damaged()
    {
        _bullet.GetComponent<Monster>().Damaged(damage);
    }

    IEnumerator AttackDelayCoroutine()
    {
        yield return new WaitForSeconds(3.5f - 3 * attackSpeed);
        _isAttack = false;
    }

    public void Travle()
    {
        float price = GameManager.Instance._saveManager._userSave.USER_CURRENTHONEY;
        price += price * travel.travelAddPercent;
        honeyAmount += Mathf.RoundToInt(price);
        Destroy(this);
    }

    public override void Reset()
    {
        _isAttack = false;

    }
}
