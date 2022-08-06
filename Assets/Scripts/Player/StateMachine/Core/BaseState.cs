public abstract class BaseState
{
    public abstract void OnEnter(StateMachine machine);
    public abstract void OnExit(StateMachine machine);
    public abstract void UpdateState(StateMachine machine);
}