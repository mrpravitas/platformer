using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;

    public void UpdateHealthUI(int currentHealth)
    {
        _healthText.text = $"HP: {currentHealth}";
    }
}
