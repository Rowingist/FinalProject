using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStartAttackTargetTransition : EnemyTransition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.ReachedTarget += OnAttack;
    }

    private void OnDisable()
    {
        _enemy.ReachedTarget -= OnAttack;
        NeedTransit = false;
    }

    private void OnAttack(bool isAttacking)
    {
        NeedTransit = isAttacking;
    }
}
