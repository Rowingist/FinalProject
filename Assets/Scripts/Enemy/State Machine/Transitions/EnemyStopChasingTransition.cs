using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopChasingTransition : EnemyTransition
{
    private float _maxChasingDistance;

    private void Start()
    {
        _maxChasingDistance = 7f;
    }

    private void Update()
    {
        StopChasingTarget(_maxChasingDistance);
    }

    private void StopChasingTarget(float maxChasingDistanse)
    {
        if (Vector2.Distance(transform.position, Target.transform.position) >= maxChasingDistanse)
            NeedTransit = true;
    }
}
