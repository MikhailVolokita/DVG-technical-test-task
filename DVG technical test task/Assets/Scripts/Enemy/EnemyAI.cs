using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Patrol,
    ChasePlayer,
    ChaseLastPlayerPos
}

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public EnemyState enemyState;

    [SerializeField] private float _lookRadius;
    [SerializeField] private float _distanceToTarget;
    [SerializeField] private float _chasetopDistance;
    [SerializeField] private Player _target;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform[] _points;
    [SerializeField] private int _currentPoint;

    private CapsuleCollider _collider;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        WaypointInitialization();
        _collider.radius = _lookRadius;
    }

    private void Update()
    {
        if(_target != null)
        {
            _distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
        }
        

        if(_distanceToTarget <= _lookRadius)
        {
            enemyState = EnemyState.ChasePlayer;
        }

        if(enemyState == EnemyState.Patrol)
        {
            Patrol();
        }
        else if(enemyState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
        }
        else if (enemyState == EnemyState.ChaseLastPlayerPos)
        {
            ChaseLastPlayerPos();
        }
    }

    public void SetPoint(Vector3 pos)
    {
        _navMeshAgent.SetDestination(pos);

    }

    private void Patrol()
    {
        _navMeshAgent.stoppingDistance = 0;
        if (_navMeshAgent.transform.position == _navMeshAgent.pathEndPosition)
        {
            UpdateTargetPoint();
        }
        SetPoint(_points[_currentPoint].position);
    }

    private void ChasePlayer()
    {
        if(_target != null)
        {
            if (_distanceToTarget > _lookRadius)
            {
                enemyState = EnemyState.ChaseLastPlayerPos;
            }
            else
            {
                _navMeshAgent.stoppingDistance = _chasetopDistance;
                _navMeshAgent.SetDestination(_target.transform.position);

            }
        }
        else
        {
            enemyState = EnemyState.ChaseLastPlayerPos;
        }
        
    }

    private void ChaseLastPlayerPos()
    {
        _navMeshAgent.stoppingDistance = 0;
        if (_navMeshAgent.transform.position == _navMeshAgent.pathEndPosition)
        {
            enemyState = EnemyState.Patrol;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            enemyState = EnemyState.ChasePlayer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            enemyState = EnemyState.ChaseLastPlayerPos;
        }
    }

    private void UpdateTargetPoint()
    {
        _currentPoint++;
        if (_currentPoint >= _points.Length)
        {
            _currentPoint = 0;
        }
    }

    private void WaypointInitialization()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
        SetPoint(_points[_currentPoint].position);
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, attackRadius);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, lookRadius);
    //}

}
