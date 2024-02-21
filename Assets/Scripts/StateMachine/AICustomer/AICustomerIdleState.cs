using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomerIdleState : BaseState<AICustomerStateMachine.AICustomerState>
{
    public AICustomerIdleState(AICustomerStateMachine.AICustomerState key, AICustomerStateMachine stateManager) : base(key, stateManager)
    { 
        _customerStateManager = stateManager;
    }

    private bool _switchState = false;
    private readonly AICustomerStateMachine _customerStateManager;

    public override void EnterState()
    {
        Debug.Log("Entering state" + StateKey);
        //find the shortest path using path finding and start walking
        _customerStateManager.Test();
    }

    public override void ExitState()
    {
        Debug.Log("Exiting state" + StateKey);
    }

    public override void UpdateState()
    {
//        Debug.Log("I am idling");
    }

    private void PlayIdleAnimation()
    {
        
    }

    public override AICustomerStateMachine.AICustomerState GetNextState()
    {
        return _switchState
            ? AICustomerStateMachine.AICustomerState.Walking
            : AICustomerStateMachine.AICustomerState.Idle;
    }
}
