using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomerEnteringState : BaseState<AICustomerStateMachine.AICustomerState>
{
    public AICustomerEnteringState(AICustomerStateMachine.AICustomerState key) : base(key)
    {
    }

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
       // Debug.Log("Updating state" + StateKey);
    }

    public override AICustomerStateMachine.AICustomerState GetNextState()
    {
        return AICustomerStateMachine.AICustomerState.Entering;
    }
}