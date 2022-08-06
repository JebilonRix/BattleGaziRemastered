using UnityEngine;

public class IdleState : BaseState
{
    public override void OnEnter(StateMachine state)
    {
    }
    public override void UpdateState(StateMachine state)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.SwitchState(state.hideState);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            state.SwitchState(state.walkState);
        }
    }
    public override void OnExit(StateMachine state)
    {
    }
}