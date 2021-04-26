using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerRunTransition : PlayerTransition
{
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        _playerMover.Input.Player.Move.Enable();
        if (_playerMover.IsMoving)
            NeedTransit = true;
    }
}
