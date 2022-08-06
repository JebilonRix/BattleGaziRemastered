using UnityEngine;

public class PatrolState : BaseEnemyState
{
    public override void OnStart(EnemyStateMechine enemyState)
    {
        enemyState.Direction = enemyState.MovingRight ? 1 : -1;
    }
    public override void OnUpdate(EnemyStateMechine enemyState)
    {
    }
    public override void OnFixedUpdate(EnemyStateMechine enemyState)
    {
        enemyState.Rb.velocity = new Vector2(enemyState.Direction * enemyState.WalkSpeed, enemyState.Rb.velocity.y);
    }
    public override void OnExit(EnemyStateMechine enemyState)
    {

    }
}