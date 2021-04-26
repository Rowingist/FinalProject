using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerState _firstState;

    private PlayerState _currentState;

    public PlayerState CurrentState => _currentState;

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(PlayerState startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void Transit(PlayerState nesxtState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nesxtState;

        if (_currentState != null)
            _currentState.Enter();
    }
}
