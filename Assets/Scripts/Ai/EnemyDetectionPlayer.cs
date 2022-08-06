using UnityEngine;

public class EnemyDetectionPlayer : EnemyDetect
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_tag))
        {
            _stateMechine.Target = other.gameObject;
            _stateMechine.SwitchState(_stateMechine.chaseState);
        }
    }
}