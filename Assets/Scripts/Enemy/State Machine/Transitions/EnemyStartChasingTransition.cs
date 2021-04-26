using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStartChasingTransition : EnemyTransition
{
    [SerializeField] private float _minMentionRadius;

    private void Update()
    {
        StartChasingTarget(_minMentionRadius);
    }

    private void StartChasingTarget(float minMentionRadius)
    {
        float distanceToTarget = Vector2.Distance(transform.position, Target.transform.position);
        
        if (distanceToTarget < minMentionRadius)
            NeedTransit = true;
    }
}
