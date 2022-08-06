using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDetect : MonoBehaviour
{
    [SerializeField] protected EnemyStateMechine _stateMechine;
    [SerializeField] protected string _tag;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;

        if (_stateMechine == null)
        {
            _stateMechine = GetComponentInParent<EnemyStateMechine>();
        }
    }
}