
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    // TODO: 의존성 있는 컴포턴트 [SerializeField]로 계속 추가해서 사용
    [SerializeField]
    private TurnManager _turnManager;
    [SerializeField]
    private List<GameObject> _countLis;
    [SerializeField]
    private List<Sprite> _playCharacterA;
    [SerializeField]
    private List<Sprite> _playCharacterB;
    [SerializeField]
    private List<Sprite> _playCharacterC;
    [SerializeField]
    private List<Sprite> _playCharacterD;

    [SerializeField]
    private GameObject _player1PlaceHolder;
    [SerializeField]
    private GameObject _player2PlaceHolder;
    [SerializeField]
    private GameObject _roundHolder;
    [SerializeField]
    private GameObject _hitRatePlayer1Holder;
    [SerializeField]
    private GameObject _hitRatePlayer2Holder;
    [SerializeField]
    private GameObject _player1decisionState;
    [SerializeField]
    private GameObject _player2decisionState;
    [SerializeField]
    private GameObject _roundPlaceholder;
    //[SerializeField]
    //private GameObject _player1HpPlaceHolder;
    //[SerializeField]
    //private GameObject _player2HpPlaceHolder;
   // [SerializeField]
   // private GameObject _heart4PlaceHolder;
   // [SerializeField]
  //  private GameObject _heart3PlaceHolder;

    

    private bool _canSelectAction = false;
    private int _roundNum = 0;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
       _turnManager.OnTurnStarted += OnTurnStart;
        _turnManager.OnTurnEnded += OnTurnEnd;
        _turnManager.OnGameStarted += OnGameStart;
        _turnManager.OnGameEnded += OnGameEnd;
    }

    private IEnumerator GameStartCoroutine()
    {
        switch (_turnManager.Player1.PlayerType)
        {
            case PlayerType.A:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterA[0];
               
                break;
            case PlayerType.B:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterB[0];
  
                break;
            case PlayerType.C:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterC[0];
                
                break;
            case PlayerType.D:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterD[0];
      
                break;
        }

        switch (_turnManager.Player2.PlayerType)
        {
            case PlayerType.A:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterA[0];
               
                break;
            case PlayerType.B:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterB[0];
         
                break;
            case PlayerType.C:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterC[0];
               
                break;
            case PlayerType.D:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterD[0];
                
                break;
        }
        // TODO: 게임 시작 시 시퀀스
        CountInitiate countInitiate = new CountInitiate();
            countInitiate.onAble(_countLis[0],_countLis[1], _countLis[2], _countLis[3]);
        yield return new WaitForSeconds(4);
        switch (_turnManager.Player1.PlayerType)
        {
            case PlayerType.A:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterA[1];
                break;
            case PlayerType.B:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterB[1];
                break;
            case PlayerType.C:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterC[1];
                break;
            case PlayerType.D:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterD[1];
                break;
        }

        switch (_turnManager.Player2.PlayerType)
        {
            case PlayerType.A:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterA[1];
                break;
            case PlayerType.B:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterB[1];
                break;
            case PlayerType.C:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterC[1];
                break;
            case PlayerType.D:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterD[1];
                break;
        }

        yield return null;
    }

    private IEnumerator GameEndCoroutine(GameResult result)
    {
        // TODO: 게임 종료 시 시퀀스
        yield return null;
    }

    private IEnumerator TurnStartCoroutine()
    {
        _canSelectAction = true;
        _roundNum++;
        float player1Hitrate = _turnManager.Player1.Ammo / _turnManager.Player1.MaxAmmo;
        float player2Hitrate = _turnManager.Player2.Ammo / _turnManager.Player2.MaxAmmo;
        _hitRatePlayer1Holder.GetComponent<TextMeshProUGUI>().text = "Hit rate " + player1Hitrate.ToString();
        _hitRatePlayer2Holder.GetComponent<TextMeshProUGUI>().text = "Hit rate " + player2Hitrate.ToString();
        _player1decisionState.SetActive(true);
        _player2decisionState.SetActive(true);
        _roundPlaceholder.GetComponent<TextMeshProUGUI>().text = _roundNum.ToString() + " Round";
        // TODO: 턴 시작 시 시퀀스
        yield return null;
    }

    private IEnumerator TurnEndCoroutine(TurnResult result)
    {
        _canSelectAction = false;
        // TODO: 턴 종료 시 시퀀스
        yield return null;
    }

    private void Update()
    {
        if (!_canSelectAction)
            return;

        // TODO: 턴 시작 후 인풋 받기
    }

    private void OnGameStart()
        => StartCoroutine(GameStartCoroutine());

    private void OnGameEnd(GameResult result)
        => StartCoroutine(GameEndCoroutine(result));

    private void OnTurnStart()
        => StartCoroutine(TurnStartCoroutine());

    private void OnTurnEnd(TurnResult result)
        => StartCoroutine(TurnEndCoroutine(result));
   private IEnumerator test()
    {
        PlayerType test = PlayerType.A;
        switch (test)
        {
            case PlayerType.A:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterA[0];
                break;
            case PlayerType.B:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterB[0];
                break;
            case PlayerType.C:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterC[0];
                break;
            case PlayerType.D:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterD[0];
                break;
        }

        switch (test)
        {
            case PlayerType.A:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterA[0];
                break;
            case PlayerType.B:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterB[0];
                break;
            case PlayerType.C:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterC[0];
                break;
            case PlayerType.D:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterD[0];
                break;
        }
        CountInitiate countInitiate = new CountInitiate();
        countInitiate.onAble(_countLis[0], _countLis[1], _countLis[2], _countLis[3]);

        yield return new WaitForSeconds(4);
        
        switch (test)
        {
            case PlayerType.A:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterA[1];
                break;
            case PlayerType.B:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterB[1];
                break;
            case PlayerType.C:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterC[1];
                break;
            case PlayerType.D:
                _player1PlaceHolder.GetComponent<Image>().sprite = _playCharacterD[1];
                break;
        }

        switch (test)
        {
            case PlayerType.A:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterA[1];
                break;
            case PlayerType.B:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterB[1];
                break;
            case PlayerType.C:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterC[1];
                break;
            case PlayerType.D:
                _player2PlaceHolder.GetComponent<Image>().sprite = _playCharacterD[1];
                break;
        }
    }
}
