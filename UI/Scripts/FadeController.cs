using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup; // ������ �� CanvasGroup

    void Start()
    {
        // �������� � ������ ������������ (������������)
        FadeOut(.5f);
    }

    public void FadeIn(float duration, Action endAction)
    {
        StartCoroutine(Fade(0f, 1f, duration, endAction)); // ���������
    }

    public void FadeOut(float duration, Action endAction)
    {
        StartCoroutine(Fade(1f, 0f, duration, endAction)); // ������������
    }

    public void FadeIn(float duration) => FadeIn(duration, null);
    public void FadeOut(float duration) => FadeOut(duration, null);

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration, Action endAction)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            _canvasGroup.alpha = alpha;
            elapsed += Time.deltaTime;
            yield return null; // ���� �� ���������� �����
        }

        // ������������� �������� �������� �����-������
        _canvasGroup.alpha = endAlpha;

        endAction?.Invoke();
    }
}
