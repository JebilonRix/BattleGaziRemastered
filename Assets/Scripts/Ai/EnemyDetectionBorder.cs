using UnityEngine;

public class EnemyDetectionBorder : EnemyDetect
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_tag))
        {
            _stateMechine.Turn();

            if (_stateMechine.GetCurrentState() != _stateMechine.patrolState)
            {
                _stateMechine.SwitchState(_stateMechine.patrolState);
            }
        }
    }
}