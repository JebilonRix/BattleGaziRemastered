using UnityEngine;

public class HideState : BaseState
{
    private const string _animName = "Hide";

    public override void OnEnter(StateMachine state)
    {
        state.Rb.velocity = Vector3.zero;
        state.DetectionCollider.enabled = false;
        state.Rb.gravityScale = 0;
        state.CapsuleCollider.enabled = false;

        state.AudioSource.PlayOneShot(state.Audios.PlayAudio("Hide", state.AudioSource));
        state.Animator.SetBool(_animName, true);
    }
    public override void UpdateState(StateMachine state)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.SwitchState(state.idleState);
        }
    }
    public override void OnExit(StateMachine state)
    {
        state.DetectionCollider.enabled = true;
        state.Rb.gravityScale = 1;
        state.CapsuleCollider.enabled = true;

        state.AudioSource.PlayOneShot(state.Audios.PlayAudio("Show", state.AudioSource));
        state.Animator.SetBool(_animName, false);
    }
}