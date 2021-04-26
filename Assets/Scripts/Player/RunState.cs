using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMover), typeof(SpriteRenderer))]
public class RunState : PlayerState
{
    private Animator _animator;
    private PlayerMover _playerMover;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        TurnRoundSprite(_playerMover.MovementDirection);
        _animator.Play("Run");
    }

    private void TurnRoundSprite(Vector2 direction)
    {
        if (direction.x > 0)
        {
            _spriteRenderer.flipX = true;

        }
        else if (direction.x < 0)
            _spriteRenderer.flipX = false;
    }
}
