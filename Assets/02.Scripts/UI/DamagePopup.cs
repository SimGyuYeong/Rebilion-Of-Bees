using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamagePopup : PoolableMono
{
    private TextMeshProUGUI _textMesh;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();

    }

    public void Setup(int damageAmount, Vector3 pos, bool isCritical, Color color)
    {
        transform.position = pos;
        _textMesh.SetText(damageAmount.ToString());

        if (isCritical)
        {
            _textMesh.color = Color.red;
            _textMesh.fontSize = 12f;
        }
        else
        {
            _textMesh.color = color;
        }

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOJump(new Vector3(pos.x + Random.Range(-1f, 1f), pos.y, pos.x), 0.8f, 1, 1f));
        //seq.Append(transform.DOMoveY(transform.position.y + 0.7f, 1f));
        seq.Join(_textMesh.DOFade(0, 1f));
        seq.AppendCallback(() =>
        {
            PoolManager.Instance.Push(this);
        });
    }

    public override void Reset()
    {
        _textMesh.color = Color.white;
        _textMesh.fontSize = 7f;
    }
}
