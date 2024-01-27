
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InitiationUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _player1Gun;
    [SerializeField]
    private GameObject _player2Gun;
    [SerializeField]
    private GameObject _player1Heart;
    [SerializeField]
    private GameObject _player2Heart;
    [SerializeField]
    private GameObject _player1Character;
    [SerializeField]
    private GameObject _player2Character;
    [SerializeField]
    private List<Sprite> _gunList;
    [SerializeField]
    private List<Sprite> _characterList;
    [SerializeField]
    private List<GameObject> _heartImageList;

    public void OnAble(PlayerType player1, PlayerType player2)
    {
        switch (player1)
        {
            case PlayerType.A:
                _player1Gun.GetComponent<Image>().sprite= _gunList[0];
                _player1Heart = _heartImageList[0];
                _player1Character.GetComponent<Image>().sprite = _characterList[0];
                break;
            case PlayerType.B:
                _player1Gun.GetComponent<Image>().sprite = _gunList[1];
                _player1Heart = _heartImageList[1];
                _player1Character.GetComponent<Image>().sprite = _characterList[1];
                break;
            case PlayerType.C:
                _player1Gun.GetComponent<Image>().sprite = _gunList[2];
                _player1Heart = _heartImageList[2];
                _player1Character.GetComponent<Image>().sprite = _characterList[2];
                break;
            case PlayerType.D:
                _player1Gun.GetComponent<Image>().sprite = _gunList[3];
                _player1Heart = _heartImageList[3];
                _player1Character.GetComponent<Image>().sprite = _characterList[3];
                break;
            
    
        }

        switch (player2)
        {
            case PlayerType.A:
                _player2Gun.GetComponent<Image>().sprite = _gunList[1];
                _player2Heart = _heartImageList[0];
                _player2Character.GetComponent<Image>().sprite = _characterList[0];
                break;
            case PlayerType.B:
                _player2Gun.GetComponent<Image>().sprite = _gunList[1];
                _player2Heart = _heartImageList[1];
                _player2Character.GetComponent<Image>().sprite = _characterList[1];
                break;
            case PlayerType.C:
                _player2Gun.GetComponent<Image>().sprite = _gunList[2];
                _player2Heart = _heartImageList[2];
                _player2Character.GetComponent<Image>().sprite = _characterList[2];
                break;
            case PlayerType.D:
                _player2Gun.GetComponent<Image>().sprite = _gunList[3];
                _player2Heart = _heartImageList[3];
                _player2Character.GetComponent<Image>().sprite = _characterList[3];
                break;


        }

        

    }

    private void Start()
    {
        OnAble(PlayerType.A, PlayerType.A);
    }
}
