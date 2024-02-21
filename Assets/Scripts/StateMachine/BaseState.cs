using System;

public abstract class BaseState<EState> where EState : Enum
{
    protected BaseState(EState key)
    {
        StateKey = key;
    }
    protected BaseState(EState key, StateManager<EState> stateManager)
    {
        StateKey = key;
        StateManager = stateManager;
    }

    public EState StateKey { get; private set; }
    protected StateManager<EState> StateManager { get; set; }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
}
