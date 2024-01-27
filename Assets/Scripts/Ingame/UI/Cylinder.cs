using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cylinder : MonoBehaviour
{
    [SerializeField]
    private int _maxAmount;
    [SerializeField]
    private GameObject _revolvingObject;
    [SerializeField]
    private Image _revolvingImage;
    [SerializeField]
    private GameObject[] _bullets;

    private int _amount;
    public int Amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = Math.Clamp(value, 0, _maxAmount);

            for (int i = 0; i < _bullets.Length; i++)
            {
                if (i < _amount)
                    _bullets[i].SetActive(true);
                else
                    _bullets[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        Amount = 0;
    }

    [ContextMenu("1")]
    public void StartRevolving()
    {
        _revolvingObject.SetActive(true);
        _revolvingImage.color = _revolvingImage.color.SetAlpha((float)_amount / (float)_maxAmount);

        for (int i = 0; i < _bullets.Length; i++)
            _bullets[i].SetActive(false);
    }

    [ContextMenu("2")]
    public void StopRevolving()
    {
        _revolvingObject.SetActive(false);
        Amount = Amount;
    }

    [ContextMenu("3")]
    public void Test()
    {
        Amount++;
    }
}