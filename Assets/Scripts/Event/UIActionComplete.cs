using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using DG.Tweening;
using UnityEditor.Profiling;
public class UIActionComplete : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Action Complte Sprite Holder")]
    [SerializeField]
    private GameObject _player0Holder;
    [SerializeField]
    private GameObject _player1Holder;
    private void OnAble(int playerindex)
    {
       
        if(playerindex == 0)
        {
            _player0Holder.SetActive(true);
            _player0Holder.GetComponent<Image>().color = Color.clear;
            _player0Holder.GetComponent<Image>().DOColor(Color.white, 2f);


        }
        else if(playerindex == 1)
        {
            _player1Holder.SetActive(true);
            _player1Holder.GetComponent<Image>().color = Color.clear;
            _player1Holder.GetComponent<Image>().DOColor(Color.white, 2f);
        }
    }
    private void OnDisable()
    {
        _player0Holder.GetComponent<Image>().DOColor(Color.clear, 2f).OnComplete(()=>_player0Holder.SetActive(false));
        _player1Holder.GetComponent<Image>().DOColor(Color.clear, 2f).OnComplete(() => _player1Holder.SetActive(false));

    }
    private void Start()
    {
        OnAble(1);
    }
}
