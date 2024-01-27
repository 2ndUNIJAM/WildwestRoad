using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CountInitiate : MonoBehaviour
{
    // Start is called before the first frame update
  
   public void onAble(GameObject count1,GameObject count2,GameObject count3,GameObject countStart)
    {
        Sequence count = DOTween.Sequence();
        count.Append(count3.transform.DOScale(Vector3.zero, 1).OnComplete(() => count3.SetActive(false)))
            .AppendCallback(() => count2.SetActive(true))
            .Append(count2.transform.DOScale(Vector3.zero, 1).OnComplete(() => count2.SetActive(false)))
            .AppendCallback(() => count1.SetActive(true))
            .Append(count1.transform.DOScale(Vector3.zero, 1).OnComplete(() => count1.SetActive(false)))
            .AppendCallback(() => countStart.SetActive(true))
            .Append(countStart.transform.DOScale(new Vector3(0.5f, 0.5f, 1), 1).OnComplete(() => countStart.SetActive(false)));
        count.Play();
    }



}
