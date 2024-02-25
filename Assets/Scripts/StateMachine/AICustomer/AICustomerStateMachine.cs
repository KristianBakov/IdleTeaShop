using UnityEngine;

public enum AICustomerState
{
    Idle,
    Walking,
    Ordering,
    Drinking,
}
public class AICustomerStateMachine : StateManager<AICustomerState>
{
    [SerializeField]
    private Transform target;
    [SerializeField] 
    private Animator animator;

    private void Awake()
    {
         States.Add(AICustomerState.Idle, new AICustomerIdleState(AICustomerState.Idle, this));
         States.Add(AICustomerState.Walking, new AICustomerWalkingState(AICustomerState.Walking));
         States.Add(AICustomerState.Ordering, new AICustomerOrderingState(AICustomerState.Ordering));
         States.Add(AICustomerState.Drinking, new AICustomerDrinkingState(AICustomerState.Drinking));
        
        CurrentState = States[AICustomerState.Idle];
    }
}
