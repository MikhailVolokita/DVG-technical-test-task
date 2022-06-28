using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpRate;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if(_target != null)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _lerpRate);
        } 
    }
}
