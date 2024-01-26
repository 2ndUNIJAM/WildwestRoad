using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnStartUI : MonoBehaviour
{
    // Start is called before the first frame update
    public  int roundNum = 0;
    [SerializeField]
    private GameObject _player0HitRate;
    [SerializeField]
    private GameObject _player1HitRate;
    [SerializeField]
    private GameObject _roundNumber;

    
    private void OnAble(float player0HitRate, float player1HitRate)
    {
        roundNum++;
        _roundNumber.GetComponent<Text>().text = roundNum.ToString() + " Round "; 
        _player0HitRate.GetComponent<Text>().text = "적중률 " + player0HitRate.ToString() +"%";
        _player1HitRate.GetComponent<Text>().text = "적중률 " + player1HitRate.ToString() +"%";
    }


}

