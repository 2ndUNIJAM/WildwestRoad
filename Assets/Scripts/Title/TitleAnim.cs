using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnim : MonoBehaviour
{
    public RectTransform uiTransform;
    public float animationDuration = 2.0f;
    public Vector2 targetSize = new Vector2(1920, 1080); // 목표 크기 설정

    void Start()
    {
        // StartCoroutine(AnimateSize());
        uiTransform.DOSizeDelta(targetSize, animationDuration).SetEase(Ease.OutSine);
    }

    IEnumerator AnimateSize()
    {
        Vector2 startSize = uiTransform.sizeDelta;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            uiTransform.sizeDelta = Vector2.Lerp(startSize, targetSize, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uiTransform.sizeDelta = targetSize; // 최종 크기로 설정
    }
}
