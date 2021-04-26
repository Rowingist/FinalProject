using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransition : MonoBehaviour
{
    [SerializeField] private PlayerState _palyerTargetState;

    public PlayerState PlayerTargetState => _palyerTargetState;

    public bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
