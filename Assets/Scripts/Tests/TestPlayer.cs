using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    private PlayerFactory _playerFactory = new();
    [SerializeField]
    private PlayerType _playerType1;
    [SerializeField]
    private PlayerType _playerType2;
    public Player player1;
    public Player player2;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        player1 = _playerFactory.CreatePlayer(_playerType1);
        player2 = _playerFactory.CreatePlayer(_playerType2);

        player2.SetAction(PlayerActionType.Reload);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player1.ResetFlags();
            player2.ResetFlags();

            Debug.Log(player1.ToString());
            Debug.Log(player2.ToString());

            player1.Fire(player2);

            Debug.Log(player1.ToString());
            Debug.Log(player2.ToString());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            player1.ResetFlags();
            player2.ResetFlags();

            Debug.Log(player1.ToString());
            Debug.Log(player2.ToString());

            Debug.Log(player1.ToString());
            Debug.Log(player2.ToString());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            player1.ResetFlags();
            player2.ResetFlags();

            Debug.Log(player1.ToString());
            Debug.Log(player2.ToString());

            player1.ReloadAmmo();
            player2.Fire(player1);

            Debug.Log(player1.ToString());
            Debug.Log(player2.ToString());
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            player1.ResetFlags();
            player1.ReloadAmmo();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            player2.ResetFlags();
            Debug.Log(player2.TryFire());
        }
    }
}