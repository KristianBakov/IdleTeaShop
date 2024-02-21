using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomerDrinkingState : BaseState<AICustomerStateMachine.AICustomerState>
{
    public AICustomerDrinkingState(AICustomerStateMachine.AICustomerState key) : base(key)
    {
    }

    private bool switchState = false;

    public override void EnterState()
    {
        Debug.Log("Entering state" + StateKey);
        //find the shortest path using path finding and start walking
    }

    public override void ExitState()
    {
        Debug.Log("Exiting state" + StateKey);
    }

    public override void UpdateState()
    {
        //Debug.Log("Updating state" + StateKey);
    }

    public override AICustomerStateMachine.AICustomerState GetNextState()
    {
        return switchState
            ? AICustomerStateMachine.AICustomerState.Walking
            : AICustomerStateMachine.AICustomerState.Drinking;
    }
}
