public abstract class BaseEnemyState
{
    public abstract void OnStart(EnemyStateMechine enemyState);
    public abstract void OnExit(EnemyStateMechine enemyState);
    public abstract void OnUpdate(EnemyStateMechine enemyState);
    public abstract void OnFixedUpdate(EnemyStateMechine enemyState);
}
