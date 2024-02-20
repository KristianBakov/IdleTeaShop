using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{ 
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();

    protected BaseState<EState> CurrentState;

    protected bool IsTransitioningState = false;

    private void Start()
    {
        CurrentState.EnterState();
    }

    private void Update()
    {
        if(IsTransitioningState) return;
        EState nextStateKey = CurrentState.GetNextState();
        if (nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else
        {
            TransitionToState(nextStateKey);
        }
        
        CurrentState.UpdateState();
    }

    private void TransitionToState(EState nextStateKey)
    {
        IsTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[nextStateKey];
        CurrentState.EnterState();
        IsTransitioningState = false;
    }
}
