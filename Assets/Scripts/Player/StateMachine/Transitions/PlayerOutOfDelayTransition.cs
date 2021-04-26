using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfDelayTransition : PlayerTransition
{
    [SerializeField] private float _animationDelay;

    private float _delayTime;

    public float DelayTime => _delayTime;

    private void Start()
    {
        _delayTime = _animationDelay;
    }

    private void Update()
    {
        _delayTime -= Time.deltaTime;

        if (_delayTime <= 0)
        {
            NeedTransit = true;
            _delayTime = _animationDelay;
        }
    }
}
