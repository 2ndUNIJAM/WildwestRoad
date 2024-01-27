using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnStartUI : MonoBehaviour
{
    // Start is called before the first frame update
    public  int roundNum = 0;
    [SerializeField]
    private GameObject _player1HitRate;
    [SerializeField]
    private GameObject _player2HitRate;
    [SerializeField]
    private GameObject _roundNumber;

    
    private void OnAble(float player1HitRate, float player2HitRate)
    {
        roundNum++;
        _roundNumber.GetComponent<TextMeshProUGUI>().SetText(_roundNumber +" Round ");
        _player1HitRate.GetComponent<TextMeshProUGUI>().SetText("적중률 " + player1HitRate.ToString() +"%");
        _player2HitRate.GetComponent<TextMeshProUGUI>().SetText("적중률 " + player2HitRate.ToString() +"%");
    }

    private void Start()
    {
        OnAble(0.3f, 0.3f);
    }
}

