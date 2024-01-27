using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneAnimation : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Image _action1;
    [SerializeField]
    private Image _action2;
    [SerializeField]
    private Image _specialAction1;
    [SerializeField]
    private Image _specialAction2;
    [SerializeField]
    private Image _waiting1;
    [SerializeField]
    private Image _waiting2;
    [SerializeField]
    private Image _result1;
    [SerializeField]
    private Image _result2;
    [SerializeField]
    private Image _bg;
    [SerializeField]
    private Color _bgColor;

    [Header("Images")]
    // 순서: Attack, Dodge, Reload
    [SerializeField]
    private List<Sprite> _leftActionImages;
    // 순서: Attack, Dodge, Reload
    [SerializeField]
    private List<Sprite> _rightActionImages;
    [SerializeField]
    private List<Sprite> _waitingImages;
    // 순서: Misfire, Dodge, Hit
    [SerializeField]
    private List<Sprite> _resultImages;
    // 0: Langer left, 1: Langer right, 2: Max left, 3: Max right, 4: Loki, 5: Nadesiko
    [SerializeField]
    private List<Sprite> _specialImages;

    [ContextMenu("Test Animation")]
    public void Test()
    {
        var result = new TurnResult()
        {
            HealthDiff1 = 0,
            HealthDiff2 = 0,
            AmmoDiff1 = 2,
            AmmoDiff2 = 0,
            MaxAmmoDiff1 = 0,
            MaxAmmoDiff2 = 0,
            Action1 = PlayerActionType.Reload,
            Action2 = PlayerActionType.Attack,
            IsUltimateUsed1 = true,
            IsUltimateUsed2 = false
        };

        StartCoroutine(AnimationCoroutine(result));
    }

    // TODO: 사운드 넣어야함
    public IEnumerator AnimationCoroutine(TurnResult result)
    {
        Reset();
        var player1Type = GameManager.Instance.Player1Type;
        var player2Type = GameManager.Instance.Player2Type;

        _bg.gameObject.SetActive(true);
        _bg.color = Color.clear;
        _bg.DOColor(_bgColor, .2f);

        // Show action image
        _action1.gameObject.SetActive(true);
        _action1.sprite = _leftActionImages[(int)player1Type * 3 + (int)result.Action1];
        _action1.color = Color.clear;
        _action1.DOColor(Color.white, .2f);

        if (player1Type == PlayerType.A && result.IsUltimateUsed1)
        {
            yield return new WaitForSeconds(1f);

            _specialAction1.gameObject.SetActive(true);
            _specialAction1.sprite = _specialImages[0];
            _specialAction1.color = Color.clear;
            _specialAction1.DOColor(Color.white, .5f);
        }

        if (player1Type == PlayerType.C && result.IsUltimateUsed1)
        {
            yield return new WaitForSeconds(1f);

            _specialAction1.gameObject.SetActive(true);
            _specialAction1.sprite = _specialImages[2];
            _specialAction1.color = Color.clear;
            _specialAction1.DOColor(Color.white, .5f);
        }

        yield return new WaitForSeconds(2f);
        _action2.gameObject.SetActive(true);
        _action2.sprite = _rightActionImages[(int)player2Type * 3 + (int)result.Action2];
        _action2.color = Color.clear;
        _action2.DOColor(Color.white, .2f);

        if (player2Type == PlayerType.A && result.IsUltimateUsed2)
        {
            yield return new WaitForSeconds(1f);

            _specialAction2.gameObject.SetActive(true);
            _specialAction2.sprite = _specialImages[1];
            _specialAction2.color = Color.clear;
            _specialAction2.DOColor(Color.white, .5f);
        }

        if (player1Type == PlayerType.C && result.IsUltimateUsed1)
        {
            yield return new WaitForSeconds(1f);

            _specialAction2.gameObject.SetActive(true);
            _specialAction2.sprite = _specialImages[3];
            _specialAction2.color = Color.clear;
            _specialAction2.DOColor(Color.white, .5f);
        }

        yield return new WaitForSeconds(2f);

        _action1.gameObject.SetActive(false);
        _action2.gameObject.SetActive(false);
        _specialAction1.gameObject.SetActive(false);
        _specialAction2.gameObject.SetActive(false);

        // Show waiting image and result image if player1 fires a gun
        if (result.Action1 == PlayerActionType.Attack)
        {
            _waiting2.gameObject.SetActive(true);
            _waiting2.sprite = _waitingImages[(int)player2Type];
            _waiting2.color = Color.clear;
            _waiting2.DOColor(Color.white, .2f);

            yield return new WaitForSeconds(3f);

            _result2.gameObject.SetActive(true);
            _result2.color = Color.clear;
            _result2.DOColor(Color.white, .2f);

            // misfire
            if (result.AmmoDiff1 == 0 && player1Type != PlayerType.C)
            {
                _result2.sprite = _resultImages[(int)player1Type * 3];
            }
            // max misfire
            else if (player1Type == PlayerType.C && result.HealthDiff2 == 0)
            {
                _result2.sprite = _resultImages[(int)player1Type * 3];

                // max misfire with na ultimate
                if (player2Type == PlayerType.D && result.IsUltimateUsed2)
                    _result2.sprite = _specialImages[5];
            }
            // dodge
            else if (result.Action2 == PlayerActionType.Dodge)
            {
                _result2.sprite = _resultImages[(int)player2Type * 3 + 1];

                if (player2Type == PlayerType.B && result.IsUltimateUsed2)
                    _result2.sprite = _specialImages[4];
            }
            // hit
            else
            {
                _result2.sprite = _resultImages[(int)player2Type * 3 + 2];

                if (player2Type == PlayerType.D && result.HealthDiff2 == 0 && result.IsUltimateUsed2)
                    _result2.sprite = _specialImages[5];
            }

            yield return new WaitForSeconds(2f);
        }

        // Show waiting image and result image if player2 fires a gun
        if (result.Action2 == PlayerActionType.Attack)
        {
            _waiting2.gameObject.SetActive(false);
            _result2.gameObject.SetActive(false);

            _waiting1.gameObject.SetActive(true);
            _waiting1.sprite = _waitingImages[(int)player1Type];
            _waiting1.color = Color.clear;
            _waiting1.DOColor(Color.white, .2f);

            yield return new WaitForSeconds(3f);

            _result1.gameObject.SetActive(true);
            _result1.color = Color.clear;
            _result1.DOColor(Color.white, .2f);

            // misfire
            if (result.AmmoDiff2 == 0 && player2Type != PlayerType.C)
            {
                _result1.sprite = _resultImages[(int)player2Type * 3];
            }
            // max misfire
            else if (player2Type == PlayerType.C && result.HealthDiff1 == 0)
            {
                _result1.sprite = _resultImages[(int)player2Type * 3];

                // max misfire with na ultimate
                if (player1Type == PlayerType.D && result.IsUltimateUsed1)
                    _result1.sprite = _specialImages[5];
            }
            // dodge
            else if (result.Action1 == PlayerActionType.Dodge)
            {
                _result1.sprite = _resultImages[(int)player1Type * 3 + 1];

                if (player1Type == PlayerType.B && result.IsUltimateUsed1)
                    _result1.sprite = _specialImages[4];
            }
            // hit
            else
            {
                _result1.sprite = _resultImages[(int)player1Type * 3 + 2];

                if (player1Type == PlayerType.D && result.HealthDiff1 == 0 && result.IsUltimateUsed1)
                    _result1.sprite = _specialImages[5];
            }

            yield return new WaitForSeconds(2f);
        }

        _bg.DOColor(Color.clear, .2f);
        yield return new WaitForSeconds(.2f);

        // Finish animation
        Reset();
    }

    private void Reset()
    {
        _bg.gameObject.SetActive(false);
        _action1.gameObject.SetActive(false);
        _action2.gameObject.SetActive(false);
        _specialAction1.gameObject.SetActive(false);
        _specialAction2.gameObject.SetActive(false);
        _waiting1.gameObject.SetActive(false);
        _waiting2.gameObject.SetActive(false);
        _result1.gameObject.SetActive(false);
        _result2.gameObject.SetActive(false);
    }
}