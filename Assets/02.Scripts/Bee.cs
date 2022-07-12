using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : MonoBehaviour
{
    public string beeName; // �� �̸�
    public string honeyType; // �� �Ӽ�
    public long level; // ����
    public long damage; // ���ݷ�
    public float attackSpeed; // ���ݼӵ�
    public float critical; // ũ��Ƽ�� Ȯ��
    public int honeyAmount; // ����� ���޵� �ܷ�
    public string rangeType; // ���� Ÿ�� ( �ٰŸ�,�߰Ÿ�,���Ÿ� )
    public string info; // ����
    public Image icon; // ������

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
