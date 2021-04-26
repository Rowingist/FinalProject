using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class EnemyHangAroundState : EnemyState
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetwenChangingDirection;
   
    private float _currentTime;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _startingPosition;
    private Vector3 _roamingPosition;
    private Vector3 _previousPosition;

    private void Start()
    {
        _startingPosition = transform.position;
        _roamingPosition = GetRoamingPosition();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FlipRound();
        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeBetwenChangingDirection)
        {
            _currentTime = 0;
            _roamingPosition = GetRoamingPosition();
        }

        _animator.Play("Run");
        _previousPosition = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _roamingPosition, _speed * Time.deltaTime);
    }

    private Vector3 GetRoamingPosition()
    {
        return _startingPosition + GetRandomDirection() * Random.Range(7f, 10f);
    }

    private Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f,1f)).normalized;
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
