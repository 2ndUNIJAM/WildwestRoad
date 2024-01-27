using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TurnEndMidUI : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _typeASprite;
    [SerializeField]
    private List<Sprite> _typeBSprite;
    [SerializeField]
    private List<Sprite> _typeCSprite;
    [SerializeField]
    private List<Sprite> _typeDSprite;
    [SerializeField]
    private GameObject _player1SpriteHolder;
    [SerializeField]
    private GameObject _player2SpriteHolder;
    [SerializeField]
    private GameObject _midSpriteHolder;
    [SerializeField]
    private List<Sprite> _midSpriteLis;

    private  List<Sprite> _player1Sprite = new List<Sprite>();
    private  List<Sprite> _player2Sprite = new List<Sprite>();

  
    private void OnAble(PlayerType player1Type, PlayerType player2Type, TurnResult turnResult)
    {
        IEnumerator midUIReveal()
        {
            switch (player1Type)
            {
                case PlayerType.A:
                    _player1Sprite = _typeASprite;
                    break;
                case PlayerType.B:
                    _player1Sprite = _typeBSprite;
                    break;
                case PlayerType.C:
                    _player1Sprite = _typeCSprite;
                    break;
                case PlayerType.D:
                    _player1Sprite = _typeDSprite;
                    break;

            }
            switch (player2Type)
            {
                case PlayerType.A:
                    _player2Sprite = _typeASprite;
                    break;
                case PlayerType.B:
                    _player2Sprite = _typeBSprite;
                    break;
                case PlayerType.C:
                    _player2Sprite = _typeCSprite;
                    break;
                case PlayerType.D:
                    _player2Sprite = _typeDSprite;
                    break;
            }
            switch ((turnResult.Action1, turnResult.Action2))
            {
                case (PlayerActionType.Attack, PlayerActionType.Reload):
                    if (turnResult.AmmoDiff2 != 0)
                    {

                        animationReveal(_player1Sprite[0], _player1SpriteHolder);

                        yield return new WaitForSeconds(2.0f);

                        animationReveal(_player1Sprite[1], _player2SpriteHolder);

                        yield return new WaitForSeconds(2.0f);

                        animationReveal(_midSpriteLis[0], _midSpriteHolder);

                        yield return new WaitForSeconds(2.0f);

                        

                    }
                    break;

                case (PlayerActionType.Attack, PlayerActionType.Dodge):
                    if (turnResult.AmmoDiff2 != 0)
                    {
                        _player1SpriteHolder.SetActive(true);

                        _player1SpriteHolder.GetComponent<Image>().color = Color.clear;
                        _player1SpriteHolder.GetComponent<Image>().sprite = _player1Sprite[0];
                        _player1SpriteHolder.GetComponent<Image>().DOColor(Color.white, 2f);



                        _player2SpriteHolder.SetActive(true);
                        _player2SpriteHolder.GetComponent<Image>().color = Color.clear;
                        _player2SpriteHolder.GetComponent<Image>().sprite = _player2Sprite[1];
                        _player2SpriteHolder.GetComponent<Image>().DOColor(Color.white, 2f);



                        _midSpriteHolder.SetActive(true);
                        _midSpriteHolder.GetComponent<Image>().color = Color.clear;
                        _midSpriteHolder.GetComponent<Image>().DOColor(Color.white, 2f);
                    }
                    break;

                case (PlayerActionType.Attack, PlayerActionType.Attack):
                    if (turnResult.AmmoDiff2 != 0)
                    {


                        animationFade(_player1Sprite[0], _player1SpriteHolder);
                        ///_player1SpriteHolder.GetComponent<Image>().color = Color.clear;
                        /// _player1SpriteHolder.GetComponent<Image>().sprite = _player1Sprite[0];
                        /// _player1SpriteHolder.GetComponent<Image>().DOColor(Color.white, 5f);



                        animationFade(_player1Sprite[0], _player2SpriteHolder);

                        ///  _player2SpriteHolder.SetActive(true);
                        ///    _player2SpriteHolder.GetComponent<Image>().color = Color.clear;
                        ///  _player2SpriteHolder.GetComponent<Image>().sprite = _player2Sprite[0];
                        ///  _player2SpriteHolder.GetComponent<Image>().DOColor(Color.white, 5f);



                        _midSpriteHolder.SetActive(true);
                        _midSpriteHolder.GetComponent<Image>().color = Color.clear;
                        _midSpriteHolder.GetComponent<Image>().DOColor(Color.white, 5f);
                    }
                    break;


            }
        }   
      ///  _player1SpriteHolder.SetActive(false);
      ///  _player2SpriteHolder.SetActive(false);
      ///  _midSpriteHolder.SetActive(false);
    }
    void animationFade(Sprite sprite, GameObject placeholder)
    {
        placeholder.SetActive(true);
        placeholder.GetComponent<Image>().sprite = sprite;
        placeholder.GetComponent<Image>().DOFade(0, 4);
        
    }

    void animationReveal(Sprite sprite, GameObject placeholder)
    {
        placeholder.SetActive(true);
        placeholder.GetComponent<Image>().color = Color.white;
        placeholder.GetComponent<Image>().DOColor(Color.white, 3f);
    }
    
    private void Start()
    { TurnResult test = new TurnResult();
        test.Action1 = PlayerActionType.Attack;
        test.Action2 = PlayerActionType.Attack;
        test.AmmoDiff2 = -1;
        OnAble(PlayerType.A, PlayerType.A, test);
    }
}
