using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TickAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(6, 6, 0), .1f)).Append(transform.DOScale(new Vector3(2, 2, 0), .1f));
    }
}
