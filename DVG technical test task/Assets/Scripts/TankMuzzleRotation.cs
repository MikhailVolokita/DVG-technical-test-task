using UnityEngine;

public class TankMuzzleRotation : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;
    [SerializeField] private int _indexCurrentTarget;
    [SerializeField] private float _lookRotationRadius;

    private void Update()
    {
        GetTarget();
        if(_targets[_indexCurrentTarget] != null)
        {
            if(CheckDistance())
            {
                Vector3 toTarget = _targets[_indexCurrentTarget].position - transform.position;
                transform.rotation = Quaternion.LookRotation(toTarget);
            }
        }
    }
    private void GetTarget()
    {
        float minDistance = Mathf.Infinity;
        _indexCurrentTarget = 0;
        for (int i = 0; i < _targets.Length; i++)
        {
            if(_targets[i] != null)
            {
                float distance = Vector3.Distance(transform.position, _targets[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    _indexCurrentTarget = i;
                }
            }
        }
    }
    public bool CheckDistance()
    {
        if(_targets[_indexCurrentTarget] != null)
        {
            if (_lookRotationRadius >= Vector3.Distance(_targets[_indexCurrentTarget].position, transform.position))
            {
                return true;
            }
        }
        return false;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(transform.position, _lookRotationRadius);
    //}
}
