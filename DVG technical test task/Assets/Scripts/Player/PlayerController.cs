using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private float _moveSpeed = 5;

    private Rigidbody _rigidbody;
    private float _moveX;
    private float _moveZ;

    private Vector3 _lookDirection;
    private bool _isMoving = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            PlayerMove();
        }

        if(Input.GetMouseButtonUp(0))
        {
            PlayerStop();
        }
    }

    private void PlayerMove()
    {
        if(!_isMoving)
        {
            _isMoving = true;
        }

        _moveX = _floatingJoystick.Horizontal;
        _moveZ = _floatingJoystick.Vertical;

        _rigidbody.velocity = new Vector3(_moveX * _moveSpeed, _rigidbody.velocity.y, _moveZ*_moveSpeed);

        _lookDirection = new Vector3(_moveX, 0f, _moveZ);

        if(_lookDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + _lookDirection);
        }
    }

    private void PlayerStop()
    {
        _rigidbody.velocity = Vector3.zero;
        _isMoving = false;
    }
}
