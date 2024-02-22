using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkFullState : BaseState<DrinkState>
{
    public DrinkFullState(DrinkState key, StateManager<DrinkState> stateManager) : base(key, stateManager)
    {
    }
    
    bool transitionState = false;

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }
    
    public override void UpdateState()
    {

    }

    public override DrinkState GetNextState()
    {
        return transitionState ? DrinkState.Empty : DrinkState.Full;
    }
}