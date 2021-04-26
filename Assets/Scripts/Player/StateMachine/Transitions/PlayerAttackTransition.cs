using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerAttackTransition : PlayerTransition
{
    [SerializeField] private Collider2D _collider2D;

    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (_playerMover.Input.Player.Attack.triggered)
        {
            _collider2D.enabled = true;
            NeedTransit = true;
        }
    }
}
