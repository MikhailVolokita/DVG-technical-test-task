using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
