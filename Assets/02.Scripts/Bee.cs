using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
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
        if(collision.collider.tag == "Monster")
        {
            Attack(collision.transform);
        }
    }

    public void Attack(Transform monsterTrm)
    {
        GameObject bullet = new GameObject();
        bullet.AddComponent<Image>().sprite = bulletSprite;

        Sequence seq = DOTween.Sequence();
        seq.Append(bullet.transform.DOMove(monsterTrm.position, 1f));
        seq.AppendCallback(() =>
        {
            bullet.GetComponent<Monster>().Damaged(damage);
        });
    }

    public void Travle()
    {
        float price = GameManager.Instance._saveManager._userSave.USER_CURRENTHONEY;
        price += price * travel.travelAddPercent;
        honeyAmount += Mathf.RoundToInt(price);
        Destroy(this);
    }
}
