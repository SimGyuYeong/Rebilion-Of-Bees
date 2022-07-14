using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Bullet : PoolableMono
{
    private Transform _targetTransform;

    public void Init(Sprite sprite, Transform targetTrm, Vector3 pos)
    {
        transform.position = pos;
        GetComponent<SpriteRenderer>().sprite = sprite;
        _targetTransform = targetTrm;
    }

    public void Shoot(Action callback)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(_targetTransform.position, 1f));
        seq.AppendCallback(() => callback?.Invoke());
        seq.AppendCallback(() => PoolManager.Instance.Push(this));
    }

    public override void Reset()
    {
        transform.localRotation = Quaternion.identity;
    }
}
