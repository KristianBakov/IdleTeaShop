using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICustomerStateMachine : StateManager<AICustomerStateMachine.AICustomerState>
{
    public enum AICustomerState
    {
        Idle,
        Entering,
        Ordering,
        Drinking,
        Leaving
    }
    
    public float walkSpeed = 1.0f;

    private void Awake()
    {
        //Add all states to the dictionary in a loop
        // foreach (AICustomerState state in Enum.GetValues(typeof(AICustomerState)))
        // {
        //     States.Add(state, CreateState(state));
        // }
        States.Add(AICustomerState.Idle, new AICustomerIdleState(AICustomerState.Idle));
        States.Add(AICustomerState.Entering, new AICustomerEnteringState(AICustomerState.Entering));
        
        CurrentState = States[AICustomerState.Idle];
        
    }
}
