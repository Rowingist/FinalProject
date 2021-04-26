using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private List<PlayerTransition> _transitions;

    protected Enemy Target { get; set; }

    public void Enter()
    {
        if (!enabled)
        {
            enabled = true;

            foreach(var transition in _transitions)
                transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public PlayerState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.PlayerTargetState;
            }
        }

        return null;
    }
}
