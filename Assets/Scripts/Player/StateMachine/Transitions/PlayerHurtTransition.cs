using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHurtTransition : PlayerTransition
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.HasHurt += OnPlayerHurt;
    }

    private void OnDisable()
    {
        _player.HasHurt -= OnPlayerHurt;
        NeedTransit = false;
    }

    private void OnPlayerHurt(bool isHurt)
    {
        NeedTransit = isHurt;
    }
}
