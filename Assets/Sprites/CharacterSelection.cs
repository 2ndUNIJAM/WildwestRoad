using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> CharSelectedList;
    public List<GameObject> CharSelectedList2;

    public List<GameObject> CharWantedList1;
    public List<GameObject> CharWantedList2;

    public List<GameObject> CharImageList;

    private int _currentPlayer1 = 0; // 현재 선택된 플레이어1
    private int _currentPlayer2 = 0; // 현재 선택된 플레이어2

    private bool _player1Confirmed = false; // 플레이어 1의 확정 여부
    private bool _player2Confirmed = false; // 플레이어 2의 확정 여부

    private bool _player1Selected = false;
    private bool _player2Selected = false;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        // 처음 시작 시 선택된 캐릭터 활성화
        CharSelectedList[_currentPlayer1].SetActive(true);
        CharSelectedList[_currentPlayer2].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player1Confirmed) // 플레이어1이 확정되지 않았을 때에만 움직임 처리
        {
            MovePlayer1();
        }

        if (!_player2Confirmed) // 플레이어2가 확정되지 않았을 때에만 움직임 처리
        {
            MovePlayer2();
        }

        if (Input.GetKeyDown(KeyCode.S) && !_player1Confirmed)
        {
            if (CharSelectedList2[_currentPlayer1].activeSelf)
            {
                return;
            }
            _player1Confirmed = true;
            _player1Selected = true;
            CharWantedList1[_currentPlayer1].SetActive(true);
            ChangeColor(CharImageList[_currentPlayer1]);
            Debug.Log("Player 1 confirmed with character " + _currentPlayer1);

        }
        else if (Input.GetKeyDown(KeyCode.W) && _player1Confirmed)
        {
            _player1Confirmed = false;
            _player1Selected = false;
            CharWantedList1[_currentPlayer1].SetActive(false);
            ResetColor(CharImageList[_currentPlayer1]);
            Debug.Log("Player 1 unconfirmed");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !_player2Confirmed)
        {
            if (CharSelectedList[_currentPlayer2].activeSelf)
            {
                return;
            }
            /*if (CharSelectedList[0].activeSelf || CharSelectedList[1].activeSelf ||
                CharSelectedList[2].activeSelf || CharSelectedList[3].activeSelf)
            {
                return;
            }*/
            _player2Confirmed = true;
            _player2Selected = true;
            CharWantedList2[_currentPlayer2].SetActive(true);
            ChangeColor(CharImageList[_currentPlayer2]);
            Debug.Log("Player 2 confirmed with character " + _currentPlayer2);

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && _player2Confirmed)
        {

            _player2Confirmed = false;
            _player2Selected = false;
            CharWantedList2[_currentPlayer2].SetActive(false);
            ResetColor(CharImageList[_currentPlayer2]);
            Debug.Log("Player 2 unconfirmed");
        }

        if (_player1Confirmed && _player2Confirmed)
        {
            Debug.Log("Game starting!");
        }
    }

    void MovePlayer1()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _currentPlayer1 = (_currentPlayer1 - 1 + CharSelectedList.Count) % CharSelectedList.Count;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _currentPlayer1 = (_currentPlayer1 + 1) % CharSelectedList.Count;
        }

        foreach (GameObject character in CharSelectedList)
        {
            character.SetActive(false);
        }
        CharSelectedList[_currentPlayer1].SetActive(true);
    }

    void MovePlayer2()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentPlayer2 = (_currentPlayer2 - 1 + CharSelectedList2.Count) % CharSelectedList2.Count;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentPlayer2 = (_currentPlayer2 + 1) % CharSelectedList2.Count;
        }

        foreach (GameObject character in CharSelectedList2)
        {
            character.SetActive(false);
        }
        CharSelectedList2[_currentPlayer2].SetActive(true);
    }
    void ChangeColor(GameObject obj)
    {
        CanvasRenderer renderer = obj.GetComponent<CanvasRenderer>();

        if (renderer != null)
        {
            renderer.SetColor(new Color(0.5f, 0.5f, 0.5f, 1f));
        }
    }
    void ResetColor(GameObject obj)
    {
        CanvasRenderer renderer = obj.GetComponent<CanvasRenderer>();

        if (renderer != null)
        {
            renderer.SetColor(new Color(1f, 1f, 1f, 1f));
        }
    }
}
