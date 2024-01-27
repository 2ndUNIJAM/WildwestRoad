using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public RectTransform _LeftImageRT;
    public RectTransform _ReftImageRT;
    public RectTransform _CenterImageRT;
    public GameObject menuAnim;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LeftImageHide();
            RightImageHide();
            CenterImageHide();
            menuAnim.GetComponent<MenuAnim>().ShowImage();
        }
    }

    public void RightImageShow()
    {
        _ReftImageRT.DOAnchorPosX(200, 2f).SetEase(Ease.OutCubic);
    }

    public void RightImageHide()
    {
        _ReftImageRT.DOAnchorPosX(900, 2f).SetEase(Ease.OutCubic).OnComplete(() => gameObject.SetActive(false));
    }

    public void LeftImageShow()
    {
        _LeftImageRT.DOAnchorPosX(-100, 2f).SetEase(Ease.OutCubic);
    }

    public void LeftImageHide()
    {
        _LeftImageRT.DOAnchorPosX(-800, 2f).SetEase(Ease.OutCubic);
    }

    public void CenterImageShow()
    {
        _CenterImageRT.DOAnchorPosY(0, 2f).SetEase(Ease.OutCubic);
    }

    public void CenterImageHide()
    {
        _CenterImageRT.DOAnchorPosY(1110, 2f).SetEase(Ease.OutCubic);
    }
}
