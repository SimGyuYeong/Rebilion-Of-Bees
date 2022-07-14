using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamagePopup : PoolableMono
{
    private TextMeshPro _textMesh;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshPro>();

    }

    public void Setup(int damageAmount, Vector3 pos, bool isCritical, Color color)
    {
        transform.position = pos;
        _textMesh.SetText(damageAmount.ToString());

        if (isCritical)
        {
            _textMesh.color = Color.red;
        }
        else
        {
            _textMesh.color = color;
        }

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOJump(new Vector3(pos.x + Random.Range(-0.3f, 0.3f), pos.y, pos.x), 0.3f, 1, 0.5f));
        seq.Join(_textMesh.DOFade(0, 1f));
        seq.AppendCallback(() =>
        {
            PoolManager.Instance.Push(this);
        });
    }

    public override void Reset()
    {
        _textMesh.color = Color.white;
    }
}
