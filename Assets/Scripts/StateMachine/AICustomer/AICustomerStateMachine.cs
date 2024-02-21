using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomerStateMachine : StateManager<AICustomerStateMachine.AICustomerState>
{
    public enum AICustomerState
    {
        Idle,
        Walking,
        Ordering,
        Drinking,
    }
    
    //private IStateMachineContext<ITargetable> _context;

    public void Test()
    {
        
    }

    private void Awake()
    {
         States.Add(AICustomerState.Idle, new AICustomerIdleState(AICustomerState.Idle));
         States.Add(AICustomerState.Walking, new AICustomerWalkingState(AICustomerState.Walking));
         States.Add(AICustomerState.Ordering, new AICustomerOrderingState(AICustomerState.Ordering));
         States.Add(AICustomerState.Drinking, new AICustomerDrinkingState(AICustomerState.Drinking));
        
        CurrentState = States[AICustomerState.Idle];
        //_context.SetContextObject(GetComponent<ITargetable>());
    }
}
