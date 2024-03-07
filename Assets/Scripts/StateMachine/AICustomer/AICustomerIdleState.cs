using UnityEngine;

public class AICustomerIdleState : BaseState<AICustomerState>
{
    public AICustomerIdleState(AICustomerState key, AICustomerStateMachine stateManager) : base(key, stateManager)
    { 
        _customerStateManager = stateManager as AICustomerStateMachine;
    }

    private bool _switchState = false;
    private readonly AICustomerStateMachine _customerStateManager;

    public override void EnterState()
    {
        //find the shortest path using path finding and start walking
        //Debug.Log(StateKey);
        
    }

    public override void ExitState()
    {
        Debug.Log("Customer is exiting state" + StateKey);
    }

    public override void UpdateState()
    {
        PlayIdleAnimation();
    }

    private void PlayIdleAnimation()
    {
        //play the animation here
    }

    public override AICustomerState GetNextState()
    {
        return _switchState
            ? AICustomerState.Walking
            : StateKey;
    }
}
