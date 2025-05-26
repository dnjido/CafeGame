using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup; // Ссылка на CanvasGroup

    void Start()
    {
        // Начинаем с полной прозрачности (исчезновение)
        FadeOut(.5f);
    }

    public void FadeIn(float duration, Action endAction)
    {
        StartCoroutine(Fade(0f, 1f, duration, endAction)); // Появление
    }

    public void FadeOut(float duration, Action endAction)
    {
        StartCoroutine(Fade(1f, 0f, duration, endAction)); // Исчезновение
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
            yield return null; // Ждем до следующего кадра
        }

        // Устанавливаем конечное значение альфа-канала
        _canvasGroup.alpha = endAlpha;

        endAction?.Invoke();
    }
}
