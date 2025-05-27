using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillFluid : MonoBehaviour
{
    [SerializeField] private float _fillAmount, _fillSpeed;
    [SerializeField] private GameObject _fillMesh;
    [SerializeField] private Transform _fillPointBotton, _fillPointUp;
    [SerializeField] private AudioClip _audioStart, _audioEnd;
    private bool _filled;
    private Action _complete;

    public bool filled => _filled;

    public void StartFill(Action complete)
    {
        _fillMesh.SetActive(true);
        _complete = complete;

        gameObject.layer = LayerMask.NameToLayer("Default");

        _fillMesh.transform.DOLocalMove(_fillPointUp.localPosition, _fillSpeed).SetEase(Ease.Linear);
        _fillMesh.transform.DOScale(_fillPointUp.localScale, _fillSpeed).SetEase(Ease.Linear).OnComplete(Filled);
        GetComponent<AudioSource>().PlayOneShot(_audioStart);

    }

    private void Filled()
    {
        _filled = true;

        gameObject.layer = LayerMask.NameToLayer("Interact");

        _complete?.Invoke();
        _complete = null;

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(_audioEnd);
    }
}
