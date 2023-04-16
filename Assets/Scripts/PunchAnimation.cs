using System;
using DG.Tweening;
using UnityEngine;

public class PunchAnimation : MonoBehaviour
{
    private Sequence _sequence;
    private void Start()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.25f));
        _sequence.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f));
        _sequence.PrependInterval(1f);
        _sequence.SetLoops(-1);
    }

    private void OnDestroy()
    {
        _sequence.Kill();
    }
}