using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    
    [SerializeField] private InvincibilityTimer _invincibility;

    [SerializeField] private AudioClip _damageSound;

    [Header("Events")]
    public UnityEvent<int> OnHealthChanged;
    public UnityEvent OnDamaged;
    public UnityEvent OnPlayerDeath;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        OnHealthChanged.Invoke(_currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (_invincibility != null && _invincibility.IsActive)
        {
            return;
        }

        _currentHealth -= amount;

        AudioSource.PlayClipAtPoint(_damageSound, transform.position);

        OnHealthChanged.Invoke(_currentHealth);

        if (_currentHealth <= 0 )
        {
            Die();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void Kill()
    {
        TakeDamage(_currentHealth);
    }

    private void Die()
    {
        OnPlayerDeath.Invoke();
    }
}
