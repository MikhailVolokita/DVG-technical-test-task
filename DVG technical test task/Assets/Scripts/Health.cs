using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent _eventOnTakeDamage;

    [SerializeField] private int _value;
    private HealthDisplay _healthDisplay;

    private void Awake()
    {
        _healthDisplay = GetComponent<HealthDisplay>();
    }

    private void Start()
    {
        _healthDisplay.UpdateHealthText(_value);
    }

    public void TakeDamage(float valueDamage)
    {
        _eventOnTakeDamage?.Invoke();
        _value -= (int)valueDamage;
        _healthDisplay.UpdateHealthText(_value);
        if (_value <= 0)
        {
            Die();
        }
        
    }

    public int GetValueHealth()
    {
        Debug.Log(_value);
        return _value;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
