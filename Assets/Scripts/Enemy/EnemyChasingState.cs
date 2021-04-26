using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class EnemyChasingState : EnemyState
{
    [SerializeField] private float _speedOfMovement;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _previousPosition;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FlipRound();
        _animator.Play("Run");
        _previousPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speedOfMovement * Time.deltaTime);
    }

    private void FlipRound()
    {
        if ((_previousPosition.x - transform.position.x) > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if ((_previousPosition.x - transform.position.x) < 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
