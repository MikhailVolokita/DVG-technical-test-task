using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;

    public void UpdateHealthText(int value)
    {
        _healthText.text = value.ToString();
    }
}
