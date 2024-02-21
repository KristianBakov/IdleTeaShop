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
    
    private ITargetable _context;

    protected ITargetable GetContext()
    {
        return _context ??= GetComponent<ITargetable>();
    }

    public void Test()
    {
        if (GetContext() != null && GetContext().GetGoRef() != null && GetContext().GetGoRef().transform != null)
        {
            Debug.Log("Testing" + GetContext().GetGoRef().transform.position);
        }
        
        Debug.Log("Testing" + GetContext());

    }

    private void Awake()
    {
         States.Add(AICustomerState.Idle, new AICustomerIdleState(AICustomerState.Idle, this));
         States.Add(AICustomerState.Walking, new AICustomerWalkingState(AICustomerState.Walking));
         States.Add(AICustomerState.Ordering, new AICustomerOrderingState(AICustomerState.Ordering));
         States.Add(AICustomerState.Drinking, new AICustomerDrinkingState(AICustomerState.Drinking));
        
        CurrentState = States[AICustomerState.Idle];
    }
}
