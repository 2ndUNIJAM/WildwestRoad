using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteAnimation : MonoBehaviour
{
    public Sprite[] sprites; // 스프라이트 배열, Inspector 창에서 설정 가능
    public float frameRate = 0.2f; // 프레임 속도, Inspector 창에서 설정 가능

    private Image image;
    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {
        // Image 컴포넌트 참조
        image = GetComponent<Image>();

        // 초기 스프라이트 설정
        if (sprites.Length > 0)
        {
            image.sprite = sprites[0];
        }
    }

    void Update()
    {
        // 프레임 속도에 따라 스프라이트 변경
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer = 0f;

            // 다음 프레임으로 이동
            currentFrame = (currentFrame + 1) % sprites.Length;

            // 현재 프레임의 스프라이트로 변경
            image.sprite = sprites[currentFrame];
        }
    }
}
