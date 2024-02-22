using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkEmptyState : BaseState<DrinkState>
{
    public DrinkEmptyState(DrinkState key, StateManager<DrinkState> stateManager) : base(key, stateManager)
    {
    }

    public override void EnterState()
    {
        Debug.Log("DrinkEmptyState: EnterState");
    }

    public override void ExitState()
    {
        Debug.Log("DrinkEmptyState: ExitState");
    }

    public override void UpdateState()
    {
        Debug.Log("DrinkEmptyState: UpdateState");
    }

    public override DrinkState GetNextState()
    {
        return StateKey;
    }
}