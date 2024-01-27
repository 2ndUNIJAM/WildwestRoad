using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Runtime.CompilerServices;
public class ResultPanel : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _resultChoice;

    public struct ResultData
    {
        public int winner;
        public int winnerPlayerType;
        public int loserPlayerType;
         public ResultData (int winner,int winnerPlayerType,int loserPlayerType) 
        {
            this.winner = winner;
            this.winnerPlayerType = winnerPlayerType;
            this.loserPlayerType = loserPlayerType;
        }
    }
    public ResultData resultData;


    private int _currentIndex=1;
    private void Update()
    {
        if (resultData.winner == 1 && Input.GetKeyDown(KeyCode.S) && _currentIndex > 0)
        {
            _currentIndex--;
        }
        else if
            (resultData.winner == 1 && Input.GetKeyDown(KeyCode.W )&& _currentIndex < 2){
            _currentIndex++;
        }
        else if(resultData.winner == 2 && Input.GetKeyDown(KeyCode.DownArrow) && _currentIndex > 0)
        {
            _currentIndex--;
        }
        else if(resultData.winner == 2 && Input.GetKeyDown(KeyCode.UpArrow) && _currentIndex > 2)
        {
            _currentIndex++;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            switch (_currentIndex) { 
                case 0:
                QuitGame();
                break;
            case 1:
                ReBattle(resultData);
                break;
            case 2:
                ReSelect();
                break;
        }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReBattle(ResultData resultData)
    {
        int _1p = resultData.winnerPlayerType;
        int _2p = resultData.loserPlayerType;
   
   
        GameManager.Instance.GetData(_1p, _2p);
        SceneManager.LoadScene("GameScene");
    }
    public void ReSelect()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
