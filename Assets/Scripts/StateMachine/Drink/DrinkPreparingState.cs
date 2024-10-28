using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkPreparingState : BaseState<DrinkState>
{
    public DrinkPreparingState(DrinkState key, StateManager<DrinkState> stateManager) : base(key, stateManager)
    {
        
    }

    public override void EnterState()
    {
        //Start a timer
    }

    public override void ExitState()
    {
        
    }

    public override DrinkState GetNextState()
    {
        return DrinkState.Preparing;
    }

    public override void UpdateState()
    {
        
    }
}
