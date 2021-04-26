using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTransition : MonoBehaviour
{
    [SerializeField] private EnemyState _targetStae;

    protected Player Target { get; set; }

    public EnemyState TargetState => _targetStae;

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
