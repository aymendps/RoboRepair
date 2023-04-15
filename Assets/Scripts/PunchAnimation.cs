using DG.Tweening;
using UnityEngine;

public class PunchAnimation : MonoBehaviour
{
    private void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.25f));
        sequence.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f));
        sequence.PrependInterval(1f);
        sequence.SetLoops(-1);
    }
}