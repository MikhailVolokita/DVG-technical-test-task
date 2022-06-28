using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        Vector3 toTarget = _target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toTarget);
    }
}
