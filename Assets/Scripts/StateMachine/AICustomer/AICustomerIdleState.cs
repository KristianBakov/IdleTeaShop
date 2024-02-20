using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomerIdleState : BaseState<AICustomerStateMachine.AICustomerState>
{
    
    public AICustomerIdleState(AICustomerStateMachine.AICustomerState key) : base(key)
    {
    }

    private bool switchState = false;

    public override void EnterState()
    {
        Debug.Log("Entering state" + StateKey);
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
            ? AICustomerStateMachine.AICustomerState.Entering
            : AICustomerStateMachine.AICustomerState.Idle;
    }
}
