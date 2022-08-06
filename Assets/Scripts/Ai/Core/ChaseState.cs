using UnityEngine;

public class ChaseState : BaseEnemyState
{
    private StateMachine _targetMachine;

    public override void OnStart(EnemyStateMechine enemyState)
    {
        enemyState.AudioLine(enemyState.Audio.GetRandomAudio("Run"));
        _targetMachine = enemyState.GetComponent<StateMachine>();
    }
    public override void OnUpdate(EnemyStateMechine enemyState)
    {
        if (_targetMachine != null && _targetMachine.GetCurrentState() == _targetMachine.hideState)
        {
            return;
        }
        if (Vector3.Distance(enemyState.transform.position, enemyState.Target.transform.position) < enemyState.CatchDistance)
        {
            //enemyState.AudioLine(enemyState.Audio.GetRandomAudio("Catch"));
            enemyState.PlayOne();
            enemyState.Catched();
        }
    }
    public override void OnFixedUpdate(EnemyStateMechine enemyState)
    {
        enemyState.Rb.velocity = new Vector2(enemyState.Direction * enemyState.ChaseSpeed, enemyState.Rb.velocity.y);
    }
    public override void OnExit(EnemyStateMechine enemyState)
    {
        enemyState.AudioLine(enemyState.Audio.GetRandomAudio("Seen"));
        enemyState.Target = null;
    }
}