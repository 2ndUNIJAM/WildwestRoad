using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager :SingletonBehaviour<ResultManager>
{
    [SerializeField]
    private TurnManager _turnManager;
    [SerializeField]
    private List<GameObject> _wantedLis;
    [SerializeField]
    private List<GameObject> _imageLis;

    private void InitiateObj()
    {
        if (_turnManager.Player1.Health==0 && _turnManager.Player2.Health > 0)
        {
            int index = _turnManager.Player2.PlayerType switch
            {
                PlayerType.A => 0,
                PlayerType.B => 1,
                PlayerType.C => 2,
                PlayerType.D => 3,
                _ => throw new System.Exception()

            };
            GameObject wantedElement = Instantiate(_wantedLis[index]);
            wantedElement.GetComponent<RectTransform>().DOAnchorPos(new Vector2(700, 100),2f);
            
            int anotherIndex = _turnManager.Player1.PlayerType switch
            {
                PlayerType.A => 0,
                PlayerType.B => 1,
                PlayerType.C => 2,
                PlayerType.D => 3,
                _ => throw new System.Exception()
            };
            GameObject imageElement = Instantiate(_imageLis[anotherIndex]);
            imageElement.GetComponent<RectTransform>().DOAnchorPos(new Vector2(300, 100), 2f);
            wantedElement.GetComponent<ResultPanel>().resultData = new ResultPanel.ResultData(2, index, anotherIndex);


        }
        else
        {
            if (_turnManager.Player1.Health > 0 && _turnManager.Player2.Health == 0)
            {
                int index = _turnManager.Player1.PlayerType switch
                {
                    PlayerType.A => 0,
                    PlayerType.B => 1,
                    PlayerType.C => 2,
                    PlayerType.D => 3,
                    _ => throw new System.Exception()

                };
                GameObject wantedElement = Instantiate(_wantedLis[index]);
                wantedElement.GetComponent<RectTransform>().DOAnchorPos(new Vector2(300, 100), 2f);

                int anotherIndex = _turnManager.Player2.PlayerType switch
                {
                    PlayerType.A => 0,
                    PlayerType.B => 1,
                    PlayerType.C => 2,
                    PlayerType.D => 3,
                    _ => throw new System.Exception()
                };
                GameObject imageElement = Instantiate(_imageLis[anotherIndex]);
                imageElement.GetComponent<RectTransform>().DOAnchorPos(new Vector2(700, 100), 2f);
                wantedElement.GetComponent<ResultPanel>().resultData = new ResultPanel.ResultData(1, index, anotherIndex);


            }
        }

    }

    // Start is called before the first frame update
   
   
}
