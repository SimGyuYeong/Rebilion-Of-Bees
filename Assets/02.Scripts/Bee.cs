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
    public string rangeType; // ���� Ÿ�� ( �ٰŸ�,�߰Ÿ�,���Ÿ� )
    public string info; // ����
    public bool isGet; // �ش� ���� ����°�?
    public Image icon; // ������

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
