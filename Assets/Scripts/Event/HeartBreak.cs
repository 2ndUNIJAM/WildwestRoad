using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBreak : MonoBehaviour
{
    // Start is called before the first frame update
   public IEnumerator OnAble(GameObject heartObject)
    {
        heartObject.GetComponent<Animator>().DOPlay();
        yield return new WaitForSeconds(1f);
        heartObject.SetActive(false);
        
    }
}
