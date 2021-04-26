using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player), typeof(PlayerMover))]
public class PlayerDeadTransition : PlayerTransition
{
    private Player _player;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _player.HasDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.HasDied -= OnPlayerDied;
        NeedTransit = false;
    }

    private void OnPlayerDied(bool isDead)
    {
        NeedTransit = isDead;
        _playerMover.Input.Player.Move.Disable();
    }
}
