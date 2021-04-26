using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Enemy))]
public class EnemyAttackingState : EnemyState
{
    [SerializeField] private int _attackDelay;

    private Animator _animator;
    private Enemy _enemy;

    private float _elapsedAttackTime;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        _animator.Play("Attack_1");

        if (_elapsedAttackTime <= 0)
        {
            _enemy.Attack(Target);
            _elapsedAttackTime = _attackDelay;
        }

        _elapsedAttackTime -= Time.deltaTime;
    }
}
