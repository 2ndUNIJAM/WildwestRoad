using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Image _playerImage;
    [SerializeField]
    private TextMeshProUGUI _accurateText;
    [SerializeField]
    private Transform _heart;
    [SerializeField]
    private TextMeshProUGUI _readyText;
    [SerializeField]
    private RectTransform _cylinderPos;
    private Cylinder _cylinder;
    private PlayerData _playerData;

    public Cylinder Cylinder => _cylinder;

    [Header("Resources")]
    [SerializeField]
    private PlayerSpriteData _playerSpriteData;

    public void Init(PlayerData playerData)
    {
        _playerData = playerData;

        _playerImage.sprite = _playerSpriteData.PlayerSprites[(int)playerData.Type];

        for (int i = 0; i < playerData.Health; i++)
            Instantiate(_playerSpriteData.HeartPrefab, _heart);

        var accurate = (float)playerData.Ammo / (float)playerData.MaxAmmo;
        _accurateText.text = (accurate * 100).ToString("#.##") + "%";

        var go = Instantiate(_playerSpriteData.PlayerCylinders[(int)playerData.Type], transform);
        _cylinder = go.GetComponent<Cylinder>();
        go.GetComponent<RectTransform>().anchoredPosition = _cylinderPos.anchoredPosition;

        _cylinder.Amount = playerData.Ammo;

        _readyText.gameObject.SetActive(false);
    }

    public void UpdatePlayerData(TurnResult result, int index)
    {
        if (index == 1)
        {
            _cylinder.Amount += result.AmmoDiff1;
            GetDamage(result.HealthDiff1 * -1);
        }
        else
        {
            _cylinder.Amount += result.AmmoDiff2;
            GetDamage(result.HealthDiff2 * -1);
        }

        var accurate = (float)_cylinder.Amount / (float)_playerData.MaxAmmo;
        _accurateText.text = (accurate * 100).ToString("#.##") + "%";
    }

    public IEnumerator CylinderAnimation(float duration)
    {
        _cylinder.StartRevolving();
        yield return new WaitForSeconds(duration);
        _cylinder.StopRevolving();
    }

    private void GetDamage(int amount)
    {
        var heartCount = _heart.childCount;
        var hearts = GetComponentsInChildren<HeartUI>();

        for (int i = 0; i < amount; i++)
        {
            hearts[heartCount - i - 1].PlayAnimation();
        }
    }

    public void SetReady(bool isReady)
    {
        _readyText.gameObject.SetActive(isReady);

        if (isReady)
            _playerImage.sprite = _playerSpriteData.PlayerReadySprites[(int)_playerData.Type];
        else
            _playerImage.sprite = _playerSpriteData.PlayerSprites[(int)_playerData.Type];
    }
}
