using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private float _damageMultiplier;

    private Health _health;
    
    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            _health.TakeDamage(collision.impulse.magnitude * _damageMultiplier);
            health.TakeDamage(collision.impulse.magnitude * _damageMultiplier);
        }
    }
}
