using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMover))]
public class PlayerAttackingState : PlayerState
{
    [SerializeField] private int _damage;
    [SerializeField] private Collider2D _collider2D;

    private Animator _animator;
    private PlayerMover _playerMover;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        _animator.Play("Attack");
        _playerMover.Input.Player.Move.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
            _collider2D.enabled = false;
        }
    }
}
