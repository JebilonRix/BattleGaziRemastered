using UnityEngine;

public class WalkState : BaseState
{
    private const string _animName = "Walk";
    private int _direction = 0;

    public override void OnEnter(StateMachine state)
    {
        //state.AudioSource.clip = state.WalkSfx;
        state.AudioSource.clip = state.Audios.PlayAudio("Walk", state.AudioSource);
        state.AudioSource.loop = true;
        state.AudioSource.Play();

        state.Animator.SetBool(_animName, true);
    }
    public override void UpdateState(StateMachine state)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _direction = 0;
            state.SwitchState(state.hideState);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _direction = 1;

            if (state.Sr.flipX)
            {
                state.Sr.flipX = false;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _direction = -1;

            if (!state.Sr.flipX)
            {
                state.Sr.flipX = true;
            }
        }
        else
        {
            _direction = 0;
            state.SwitchState(state.idleState);
            return;
        }
    }
    public void FixedUpdate(StateMachine state)
    {
        state.Rb.velocity = new Vector2(_direction * state.WalkingSpeed, state.Rb.velocity.y);
    }
    public override void OnExit(StateMachine state)
    {
        state.Rb.velocity = Vector2.zero;
        _direction = 0;
        state.AudioSource.loop = false;
        state.AudioSource.Stop();

        state.Animator.SetBool(_animName, false);
    }
}